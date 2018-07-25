using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Imgur.API;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using Microsoft.AspNetCore.Http;

namespace GiaoHangGiaRe.Module
{
    public class ftp_module
    {
        public void MakeRequest()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/test.htm");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.  
            request.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");

            // Copy the contents of the file to the request stream.  
            StreamReader sourceStream = new StreamReader("testfile.txt");
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        }
        public string GetImage()
        {
            try
            {
                var client = new ImgurClient("1c3d2dc52ecfa75", "157c59d9c9e52a7097376878b4e6b6867d934427");
                var endpoint = new ImageEndpoint(client);
                var image = endpoint.GetImageAsync("IMAGE_ID").GetAwaiter().GetResult();
                return image.Link;
            }
            catch (ImgurException imgurEx)
            {
                return imgurEx.Message;
            }
        }

        public string UploadImage(byte[] file)
        {
            try
            {
                var client = new ImgurClient("1c3d2dc52ecfa75", "157c59d9c9e52a7097376878b4e6b6867d934427");
                var endpoint = new ImageEndpoint(client);
                IImage image;
                image = endpoint.UploadImageBinaryAsync(file).GetAwaiter().GetResult();
                return image.Link;
            }
            catch (ImgurException imgurEx)
            {
                return imgurEx.Message;
            }
        }
    }
}