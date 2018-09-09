import Foundation
struct Json4Swift_Base : Codable {
	let listKienHang : [ListKienHang]?
	let donHang : DonHang2?

	enum CodingKeys: String, CodingKey {

		case listKienHang = "listKienHang"
		case donHang = "DonHang"
	}

	init(from decoder: Decoder) throws {
		let values = try decoder.container(keyedBy: CodingKeys.self)
		listKienHang = try values.decodeIfPresent([ListKienHang].self, forKey: .listKienHang)
        donHang = try values.decodeIfPresent(DonHang2.self, forKey: .donHang)
	}

}
