/* 
Copyright (c) 2018 Swift Models Generated from JSON powered by http://www.json4swift.com

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

For support, please feel free to contact me at https://www.linkedin.com/in/syedabsar

*/

import Foundation
struct ListKienHang : Codable {
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
