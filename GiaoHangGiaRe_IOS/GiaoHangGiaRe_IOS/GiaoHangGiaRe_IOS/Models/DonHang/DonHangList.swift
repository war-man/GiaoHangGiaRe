/* 
Copyright (c) 2018 Swift Models Generated from JSON powered by http://www.json4swift.com

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

For support, please feel free to contact me at https://www.linkedin.com/in/syedabsar

*/

import Foundation
struct DonHangList : Codable {
    let maDonHang : Int?
    let nguoiGui : String?
    let diaChiGui : String?
    let soDienThoaiNguoiGui : String?
    let nguoiNhan : String?
    let diaChiNhan : String?
    let soDienThoaiNguoiNhan : String?
    let maNhanVienGiao : String?
    let ghiChu : String?
    let tinhTrang : Int?
    let thoiDiemDatDonHang : String?
    let thoiDiemTiepNhanDon : String?
    let thoiDiemHoanThanhDH : String?
    let thanhTien : Int?
    let tenTaiKhoan : String?
    let maKhachHang : Int?
    let maHanhTrinh : String?
    let cod : String?

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
		case tenTaiKhoan = "TenTaiKhoan"
		case maKhachHang = "MaKhachHang"
		case maHanhTrinh = "MaHanhTrinh"
        case cod = "cod"
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
		maNhanVienGiao = try values.decodeIfPresent(String.self, forKey: .maNhanVienGiao)
		ghiChu = try values.decodeIfPresent(String.self, forKey: .ghiChu)
		tinhTrang = try values.decodeIfPresent(Int.self, forKey: .tinhTrang)
		thoiDiemDatDonHang = try values.decodeIfPresent(String.self, forKey: .thoiDiemDatDonHang)
		thoiDiemTiepNhanDon = try values.decodeIfPresent(String.self, forKey: .thoiDiemTiepNhanDon)
		thoiDiemHoanThanhDH = try values.decodeIfPresent(String.self, forKey: .thoiDiemHoanThanhDH)
		    thanhTien = try values.decodeIfPresent(Int.self, forKey: .thanhTien)
		tenTaiKhoan = try values.decodeIfPresent(String.self, forKey: .tenTaiKhoan)
		maKhachHang = try values.decodeIfPresent(Int.self, forKey: .maKhachHang)
		maHanhTrinh = try values.decodeIfPresent(String.self, forKey: .maHanhTrinh)
        cod = try values.decodeIfPresent(String.self, forKey: .cod)
	}

}
