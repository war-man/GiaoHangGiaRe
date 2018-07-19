using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EntityModel;

namespace GiaoHangGiaRe.Module
{
    public class KhoChuaServices : IKhoChuaServices
    {
        private IRepository<KhoChua> _khochuaRepository;
        private KienHangServices kienHangServices;
        private DonHangServices donHangServices;
        public KhoChuaServices()
        {
            _khochuaRepository = new IRepository<KhoChua>();
            kienHangServices = new KienHangServices();
            donHangServices = new DonHangServices();
        }
        public int Count()
        {
           return _khochuaRepository.GetAll().Count();
        }

        public void Create(KhoChua input)
        {
            _khochuaRepository.Insert(input);
        }

        public void Delete(int id)
        {
            _khochuaRepository.Delete(id);
        }

        public List<KhoChua> GetAll(int? page, int? size)
        {
            if (!page.HasValue) page = Constant.DefaultPage;
            if (!size.HasValue) return _khochuaRepository.GetAll().ToList();
            return _khochuaRepository.GetAll().OrderBy(p => p.MaKhoChua)
                    .Take(size.Value).Skip(size.Value * (page.Value - 1)).ToList();
        }

        public KhoChua GetById(int Id)
        {
            return _khochuaRepository.SelectById(Id);
        }

        public KhoChua GetKhoChuaOfDonHang(int MaDonHang)
        {
            throw new NotImplementedException();
            //var listkienhang=kienHangServices.GetByMaDonHang(MaDonHang);
            //return _khochuaRepository.GetAll().Where(p => p.MaKhoChua == kienHangServices.GetByMaDonHang(MaDonHang).MaKhoChua).FirstOrDefault();
        }

        public KhoChua GetKhoChuaOfKienHang(int MaKienHang)
        {
            return _khochuaRepository.GetAll()
                .Where(p => p.MaKhoChua == kienHangServices.GetById(MaKienHang)
                .MaKhoChua).FirstOrDefault();
        }

        public void Update(KhoChua input)
        {
            _khochuaRepository.Update(input);
        }
    }
}