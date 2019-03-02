import Foundation
struct DonHangShip : Codable {
    var maDonHang : Int = 0
    var nguoiGui : String = ""
	var diaChiGui : String = ""
	var soDienThoaiNguoiGui : String = ""
	var nguoiNhan : String = ""
	var diaChiNhan : String = ""
	var soDienThoaiNguoiNhan : String = ""
	var maNhanVienGiao : Int = 0
	var ghiChu : String = ""
	var tinhTrang : Int = 0
	var thoiDiemDatDonHang : String = ""
	var thoiDiemTiepNhanDon : String = ""
//    var thoiDiemHoanThanhDH : String? = ""
	var thanhTien : Int = 0
	var deleted : Bool = false
	var tenTaiKhoan : String = ""
	var maKhachHang : Int = 0
	var maHanhTrinh : Int = 0
	var cod : Int = 0

	enum CodingKeys: String, CodingKey {

		case maDonHang = "MaDonHang"
		case nguoiGui = "NguoiGui"
		case diaChiGui = "DiaChiGui"
		case soDienThoaiNguoiGui = "SoDienThoaiNguoiGui"
		case nguoiNhan = "NguoiNhan"
		case diaChiNhan = "DiaChiNhan"
		case soDienThoaiNguoiNhan = "SoDienThoaiNguoiNhan"
		case maNhanVienGiao = "MaNhanVienGiao"
		case ghiChu = "GhiChu"
		case tinhTrang = "TinhTrang"
		case thoiDiemDatDonHang = "ThoiDiemDatDonHang"
		case thoiDiemTiepNhanDon = "ThoiDiemTiepNhanDon"
//        case thoiDiemHoanThanhDH = "ThoiDiemHoanThanhDH"
		case thanhTien = "ThanhTien"
		case deleted = "deleted"
		case tenTaiKhoan = "TenTaiKhoan"
		case maKhachHang = "MaKhachHang"
		case maHanhTrinh = "MaHanhTrinh"
		case cod = "cod"
	}

	init(from decoder: Decoder) throws {
		let values = try decoder.container(keyedBy: CodingKeys.self)
        maDonHang = (try values.decodeIfPresent(Int.self, forKey: .maDonHang))!
        nguoiGui = (try values.decodeIfPresent(String.self, forKey: .nguoiGui))!
        diaChiGui = (try values.decodeIfPresent(String.self, forKey: .diaChiGui))!
        soDienThoaiNguoiGui = (try values.decodeIfPresent(String.self, forKey: .soDienThoaiNguoiGui))!
        nguoiNhan = (try values.decodeIfPresent(String.self, forKey: .nguoiNhan))!
        diaChiNhan = (try values.decodeIfPresent(String.self, forKey: .diaChiNhan))!
        soDienThoaiNguoiNhan = (try values.decodeIfPresent(String.self, forKey: .soDienThoaiNguoiNhan))!
        maNhanVienGiao = (try values.decodeIfPresent(Int.self, forKey: .maNhanVienGiao))!
        ghiChu = (try values.decodeIfPresent(String.self, forKey: .ghiChu))!
        tinhTrang = (try values.decodeIfPresent(Int.self, forKey: .tinhTrang))!
        thoiDiemDatDonHang = (try values.decodeIfPresent(String.self, forKey: .thoiDiemDatDonHang))!
        thoiDiemTiepNhanDon = (try values.decodeIfPresent(String.self, forKey: .thoiDiemTiepNhanDon))!
//        thoiDiemHoanThanhDH = (try values.decodeIfPresent(String.self, forKey: .thoiDiemHoanThanhDH))!
        thanhTien = (try values.decodeIfPresent(Int.self, forKey: .thanhTien))!
        deleted = (try values.decodeIfPresent(Bool.self, forKey: .deleted))!
        tenTaiKhoan = (try values.decodeIfPresent(String.self, forKey: .tenTaiKhoan))!
        maKhachHang = (try values.decodeIfPresent(Int.self, forKey: .maKhachHang))!
        maHanhTrinh = (try values.decodeIfPresent(Int.self, forKey: .maHanhTrinh))!
        cod = (try values.decodeIfPresent(Int.self, forKey: .cod))!
	}

}
