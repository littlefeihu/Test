using BaiduBce;
using BaiduBce.Auth;
using BaiduBce.Services.Bos;
using BaiduBce.Services.Bos.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiduWangPan
{
    public static class FileDownLoadByBce
    {
        public static void FileDownLoad()
        {
            BosClient client = GenerateBosClient();
            const string bucketName = "/aaa";    //指定Bucket名称(文件夹名称)
            const string objectKey = "a.zip";     //指定object名称（文件名字）// 获取Object
            BosObject bosObject = client.GetObject(bucketName, objectKey);
            // 获取ObjectMeta
            ObjectMetadata meta = bosObject.ObjectMetadata;
            // 获取Object的输入流
            Stream objectContent = bosObject.ObjectContent;
            // 处理Object
            FileStream fileStream = new FileInfo(objectKey).OpenWrite();      //指定下载文件的目录/文件名
            byte[] buffer = new byte[2048];
            int count = 0;
            while ((count = objectContent.Read(buffer, 0, buffer.Length)) > 0)
            {
                fileStream.Write(buffer, 0, count);
            }

            // 关闭流
            objectContent.Close();
            fileStream.Close();
        }

        private static BosClient GenerateBosClient()
        {
            const string accessKeyId = "c69c1e6d346b4d2e946715bdc4cdc13e"; // 您的Access Key ID
            const string secretAccessKey = "11021287c6fe43c498bf1b950d4d69a0"; // 您的Secret Access Key
            const string endpoint = "www.baidu.com";        //指定Bucket所在区域域名

            // 初始化一个BosClient
            BceClientConfiguration config = new BceClientConfiguration();
            config.Credentials = new DefaultBceCredentials(accessKeyId, secretAccessKey);
            config.Endpoint = endpoint;

            return new BosClient(config);
        }
    }
}