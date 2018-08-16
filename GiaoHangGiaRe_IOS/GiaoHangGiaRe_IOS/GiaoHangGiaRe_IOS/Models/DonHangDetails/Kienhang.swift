import Foundation
struct Kienhang : Codable {
	let maKienHang : Int?
	let maDonHang : Int?
	let tinhTrang : String?
	let deleted : String?
	let ghiChu : String?
	let trongLuong : Int?
	let chieuDai : Int?
	let chieuRong : Int?
	let moTa : String?
	let soLuong : Int?
	let noiDung : String?
	let maKhoChua : Int?

	enum CodingKeys: String, CodingKey {

		case maKienHang = "MaKienHang"
		case maDonHang = "MaDonHang"
		case tinhTrang = "TinhTrang"
		case deleted = "deleted"
		case ghiChu = "GhiChu"
		case trongLuong = "TrongLuong"
		case chieuDai = "ChieuDai"
		case chieuRong = "ChieuRong"
		case moTa = "MoTa"
		case soLuong = "SoLuong"
		case noiDung = "NoiDung"
		case maKhoChua = "MaKhoChua"
	}

	init(from decoder: Decoder) throws {
		let values = try decoder.container(keyedBy: CodingKeys.self)
        maKienHang = try values.decodeIfPresent(Int.self, forKey: .maKienHang)
        maDonHang = try values.decodeIfPresent(Int.self, forKey: .maDonHang)
        tinhTrang = try values.decodeIfPresent(String.self, forKey: .tinhTrang)
		deleted = try values.decodeIfPresent(String.self, forKey: .deleted)
        ghiChu = try values.decodeIfPresent(String.self, forKey: .ghiChu)
        trongLuong = try values.decodeIfPresent(Int.self, forKey: .trongLuong)
        chieuDai = try values.decodeIfPresent(Int.self, forKey: .chieuDai)
        chieuRong = try values.decodeIfPresent(Int.self, forKey: .chieuRong)
        moTa = try values.decodeIfPresent(String.self, forKey: .moTa)
        soLuong = try values.decodeIfPresent(Int.self, forKey: .soLuong)
        noiDung = try values.decodeIfPresent(String.self, forKey: .noiDung)
        maKhoChua = try values.decodeIfPresent(Int.self, forKey: .maKhoChua)
	}

}
