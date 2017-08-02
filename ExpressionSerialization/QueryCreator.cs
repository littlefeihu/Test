﻿// 源文件头信息：
// <copyright file="QueryCreator.cs">
// Copyright(c)2012-2012 EBOOOY.All rights reserved.
// CLR版本：4.0.30319.239
// 开发公司：北京易邦益科技发展有限责任公司
// 公司网站：http://www.eboooy.com
// 所属工程：ExpressionSerialization
// 最后修改：郭明锋
// 创建时间：2012/04/08 6:49
// 最后修改：2012/04/08 7:49
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace ExpressionSerialization
{
    /// <summary>
    ///   Creates (IQueryable) Query instances that actually have a backing data source. this class is almost analagous to the DLinqSerializer class in that it works with the CustomExpressionXmlConverter by providing the data source to the Query (IQueryable) when it is deserialized.
    /// </summary>
    public class QueryCreator
    {
        private readonly Func<Type, dynamic> fnGetObjects;

        #region CreateQuery

        /// <summary>
        ///   called during deserialization.
        /// </summary>
        /// <param name="elementType"> </param>
        /// <returns> </returns>
        public dynamic CreateQuery(Type elementType)
        {
            dynamic ienumerable = fnGetObjects(elementType);
            Type enumerableType = ienumerable.GetType();
            if (!typeof(IEnumerable<>).MakeGenericType(elementType).IsAssignableFrom(enumerableType))
            {
                ienumerable = Enumerable.ToArray(LinqHelper.CastToGenericEnumerable(ienumerable, elementType));
                //throw new InvalidOperationException(string.Format("Return value Type is {1}. Expected: {0}", typeof(IEnumerable<>).MakeGenericType(elementType), ienumerable.GetType()));
            }


            IQueryable queryable = Queryable.AsQueryable(ienumerable);
            IQueryProvider provider = queryable.Provider;
            Type queryType = typeof(Query<>).MakeGenericType(elementType);
            ConstructorInfo ctor = queryType.GetConstructors()[2]; //Query(IQueryProvider provider, Expression expression)
            var parameters = new[] {Expression.Parameter(typeof(IQueryProvider)), Expression.Parameter(typeof(Expression))};

            NewExpression newexpr = Expression.New(ctor, parameters);
            LambdaExpression lambda = Expression.Lambda(newexpr, parameters);
            var newFn = lambda.Compile();
            dynamic query = newFn.DynamicInvoke(new object[] {provider, Expression.Constant(queryable)});
            return query;
        }

        /// <summary>
        ///   This method is important to how this IQueryProvider works, for returning the IEnumerable from which we generate the IQueryable and IQueryProvider to delegate the Execute(Expression) call to. In practice this would be a call to the DAL.
        /// </summary>
        /// <param name="elementType"> </param>
        /// <returns> </returns>
        internal static dynamic GetIEnumerableOf(Type elementType)
        {
            Type listType = typeof(List<>).MakeGenericType(elementType);
            dynamic list = CreateDefaultInstance(listType);
            for (int i = 0; i < 10; i++)
            {
                dynamic instance = CreateDefaultInstance(elementType);
                list.Add(instance);
            }
            return list;
        }

        /// <summary>
        ///   creates instance using default ctor
        /// </summary>
        /// <param name="type"> </param>
        /// <returns> </returns>
        internal static dynamic CreateDefaultInstance(Type type)
        {
            //default ctor:
            ConstructorInfo ctor = type.GetConstructors().FirstOrDefault(c => c.GetParameters().Count() == 0);
            if (ctor == null)
            {
                throw new ArgumentException(string.Format("The type {0} must have a default (parameterless) constructor!", type));
            }

            NewExpression newexpr = Expression.New(ctor);
            LambdaExpression lambda = Expression.Lambda(newexpr);
            var newFn = lambda.Compile();
            return newFn.DynamicInvoke(new object[0]);
        }

        #endregion

        public QueryCreator()
            : this(GetIEnumerableOf)
        {}

        /// <summary>
        ///   Relies upon a function to get objects. Could alternatively have required an interface as a ctor argument, but a fn. parameters seems even more generic an approach. If we only need 1 method, then why require an entire interface? Also, this way allows a static class method to be used.
        /// </summary>
        /// <param name="fngetobjects"> function that returns a dynamic which is the IEnumerable`1 of element type that is the Type argument to the function (fngetobjects). </param>
        public QueryCreator(Func<Type, dynamic> fngetobjects)
        {
            fnGetObjects = fngetobjects;
        }

        //Func<Type, IEnumerable<object>> fnGetObjects;
    }
}