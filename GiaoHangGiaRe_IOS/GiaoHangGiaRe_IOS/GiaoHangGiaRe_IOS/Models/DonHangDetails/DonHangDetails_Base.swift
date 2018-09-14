import Foundation
struct DonHangDetais_Base : Codable {
	let donhang : Donhang?
	let kienhang : [Kienhang]?

	enum CodingKeys: String, CodingKey {

		case donhang = "donhang"
		case kienhang = "kienhang"
	}

	init(from decoder: Decoder) throws {
		let values = try decoder.container(keyedBy: CodingKeys.self)
		donhang = try values.decodeIfPresent(Donhang.self, forKey: .donhang)
		kienhang = try values.decodeIfPresent([Kienhang].self, forKey: .kienhang)
	}

}
	
