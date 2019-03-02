import Foundation

struct DonHangUser_Base : Codable {
    let listDH : [OrderUserNotFull]?
    let total : Int?
    
    enum CodingKeys: String, CodingKey {
        
        case listDH = "list"
        case total = "total"
    }
    
    init(from decoder: Decoder) throws {
        let values = try decoder.container(keyedBy: CodingKeys.self)
        listDH = try values.decodeIfPresent([OrderUserNotFull].self, forKey: .listDH)
        total = try values.decodeIfPresent(Int.self, forKey: .total)
    }
    
}

struct OrderUser : Codable {
	let maDonHang : Int?
	let nguoiGui : String?
	let diaChiGui : String?
	let soDienThoaiNguoiGui : String?
	let nguoiNhan : String?
	let diaChiNhan : String?
	let soDienThoaiNguoiNhan : String?
	let maNhanVienGiao : Int?
	let ghiChu : String?
	let tinhTrang : Int?
	let thoiDiemDatDonHang : String?
	let thoiDiemTiepNhanDon : String?
	let thoiDiemHoanThanhDH : String?
	let thanhTien : String?
	let deleted : String?
	let tenTaiKhoan : String?
	let maKhachHang : Int?
	let maHanhTrinh : String?

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
		case thoiDiemHoanThanhDH = "ThoiDiemHoanThanhDH"
		case thanhTien = "ThanhTien"
		case deleted = "deleted"
		case tenTaiKhoan = "TenTaiKhoan"
		case maKhachHang = "MaKhachHang"
		case maHanhTrinh = "MaHanhTrinh"
	}

	init(from decoder: Decoder) throws {
		let values = try decoder.container(keyedBy: CodingKeys.self)
		maDonHang = try values.decodeIfPresent(Int.self, forKey: .maDonHang)
		nguoiGui = try values.decodeIfPresent(String.self, forKey: .nguoiGui)
		diaChiGui = try values.decodeIfPresent(String.self, forKey: .diaChiGui)
        soDienThoaiNguoiGui = try values.decodeIfPresent(String.self, forKey: .soDienThoaiNguoiGui)
        nguoiNhan = try values.decodeIfPresent(String.self, forKey: .nguoiNhan)
        diaChiNhan = try values.decodeIfPresent(String.self, forKey: .diaChiNhan)
        soDienThoaiNguoiNhan = try values.decodeIfPresent(String.self, forKey: .soDienThoaiNguoiNhan)
        maNhanVienGiao = try values.decodeIfPresent(Int.self, forKey: .maNhanVienGiao)
        ghiChu = try values.decodeIfPresent(String.self, forKey: .ghiChu)
        tinhTrang = try values.decodeIfPresent(Int.self, forKey: .tinhTrang)
        thoiDiemDatDonHang = try values.decodeIfPresent(String.self, forKey: .thoiDiemDatDonHang)
        thoiDiemTiepNhanDon = try values.decodeIfPresent(String.self, forKey: .thoiDiemTiepNhanDon)
        thoiDiemHoanThanhDH = try values.decodeIfPresent(String.self, forKey: .thoiDiemHoanThanhDH)
        thanhTien = try values.decodeIfPresent(String.self, forKey: .thanhTien)
		deleted = try values.decodeIfPresent(String.self, forKey: .deleted)
        tenTaiKhoan = try values.decodeIfPresent(String.self, forKey: .tenTaiKhoan)
        maKhachHang = try values.decodeIfPresent(Int.self, forKey: .maKhachHang)
        maHanhTrinh = try values.decodeIfPresent(String.self, forKey: .maHanhTrinh)
	}

}
struct OrderUserNotFull : Codable {
    let maDonHang : Int?
    let nguoiGui : String?
    let diaChiGui : String?
    let soDienThoaiNguoiGui : String?
    let nguoiNhan : String?
    let diaChiNhan : String?
    let soDienThoaiNguoiNhan : String?
    let maNhanVienGiao : Int?
    let ghiChu : String?
    let tinhTrang : Int?
    let thoiDiemDatDonHang : String?
//    let thoiDiemTiepNhanDon : String?
    let thanhTien : Int?
    let deleted : Bool?
    let tenTaiKhoan : String?
    let maKhachHang : Int?
    let maHanhTrinh : Int?
    
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
        //case thoiDiemTiepNhanDon = "ThoiDiemTiepNhanDon"
        case thanhTien = "ThanhTien"
        case deleted = "deleted"
        case tenTaiKhoan = "TenTaiKhoan"
        case maKhachHang = "MaKhachHang"
        case maHanhTrinh = "MaHanhTrinh"
    }
    
    init(from decoder: Decoder) throws {
        let values = try decoder.container(keyedBy: CodingKeys.self)
        maDonHang = try values.decodeIfPresent(Int.self, forKey: .maDonHang)
        nguoiGui = try values.decodeIfPresent(String.self, forKey: .nguoiGui)
        diaChiGui = try values.decodeIfPresent(String.self, forKey: .diaChiGui)
        soDienThoaiNguoiGui = try values.decodeIfPresent(String.self, forKey: .soDienThoaiNguoiGui)
        nguoiNhan = try values.decodeIfPresent(String.self, forKey: .nguoiNhan)
        diaChiNhan = try values.decodeIfPresent(String.self, forKey: .diaChiNhan)
        soDienThoaiNguoiNhan = try values.decodeIfPresent(String.self, forKey: .soDienThoaiNguoiNhan)
        maNhanVienGiao = try values.decodeIfPresent(Int.self, forKey: .maNhanVienGiao)
        ghiChu = try values.decodeIfPresent(String.self, forKey: .ghiChu)
        tinhTrang = try values.decodeIfPresent(Int.self, forKey: .tinhTrang)
        thoiDiemDatDonHang = try values.decodeIfPresent(String.self, forKey: .thoiDiemDatDonHang)
        //thoiDiemTiepNhanDon = try values.decodeIfPresent(String.self, forKey: .thoiDiemTiepNhanDon)
        thanhTien = try values.decodeIfPresent(Int.self, forKey: .thanhTien)
        deleted = try values.decodeIfPresent(Bool.self, forKey: .deleted)
        tenTaiKhoan = try values.decodeIfPresent(String.self, forKey: .tenTaiKhoan)
        maKhachHang = try values.decodeIfPresent(Int.self, forKey: .maKhachHang)
        maHanhTrinh = try values.decodeIfPresent(Int.self, forKey: .maHanhTrinh)
    }
    
}
