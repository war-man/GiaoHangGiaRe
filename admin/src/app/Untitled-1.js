using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.AutoMapper;
using MyApp.Modules.Dto;
using Abp.Runtime.Validation;
using Abp.UI;
using MyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Abp.Timing;
using Microsoft.AspNetCore.Hosting;

namespace MyApp.Modules
{
    [DisableValidation]
    public class AttachFileService : MyAppAppServiceBase, IAttachFileService
    {
        private string RootFileFolder;
        private string RelativePath = "\\uploads\\";
        private string WebImagePath = "/uploads/";
        private string host = "http://localhost:21023";

        private IRepository<AttachFile,Guid> _attachFileRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AttachFileService(IRepository<AttachFile,Guid> attachFileRepository, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _attachFileRepository = attachFileRepository;
            RootFileFolder = _hostingEnvironment.WebRootPath + RelativePath;
        }

        public async Task<AttachFile> GetFile(Guid fileId)
        {
            return _attachFileRepository.Get(fileId);
        }

        public Guid CreateFile(AttachFileCreateDto input)
        {
            var timeStamp = Clock.Now.Ticks;

            string fileName = timeStamp + "." + input.FileType;
            string TeamSpaceSubForder = "teamspace_" + input.TeamSpaceId;
            string ProjectSubForder = "project_" + input.ProjectId;
            WebImagePath = WebImagePath + "project_" + input.ProjectId  + "/teamspace_" + input.TeamSpaceId+"/";
            string Forder = RootFileFolder + ProjectSubForder + "\\" + TeamSpaceSubForder;

            if (!Directory.Exists(Forder))
            {
                Directory.CreateDirectory(Forder);
            }
            //set the image path
            string filePath = Path.Combine(Forder);

            string file = input.FileContent;
            if (file != "")
            {
                byte[] contents = Convert.FromBase64String(file);
                File.WriteAllBytes(filePath, contents);
            }

            var fileInfo = input.MapTo<AttachFile>();
            fileInfo.Url = host+ WebImagePath + fileName;
            return _attachFileRepository.InsertAndGetId(fileInfo);
        }

        public Task Delete(string imageUrl)
        {
            throw new NotImplementedException();
        }
    }
}
