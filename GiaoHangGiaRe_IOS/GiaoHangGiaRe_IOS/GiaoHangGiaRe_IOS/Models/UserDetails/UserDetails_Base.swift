

import Foundation
struct UserDetails_Base : Codable {
	let claims : [String]?
	let logins : [String]?
	let roles : [Roles]?
	let hoTen : String?
	let diaChi : String?
	let imageLink : String?
	let tenTaiKhoan : String?
	let email : String?
	let phoneNumber : String?
	let id : String?
	let userName : String?

	enum CodingKeys: String, CodingKey {

		case claims = "Claims"
		case logins = "Logins"
		case roles = "Roles"
		case hoTen = "HoTen"
		case diaChi = "DiaChi"
		case imageLink = "ImageLink"
		case tenTaiKhoan = "TenTaiKhoan"
		case email = "Email"
		case phoneNumber = "PhoneNumber"
		case id = "Id"
		case userName = "UserName"
	}

	init(from decoder: Decoder) throws {
		let values = try decoder.container(keyedBy: CodingKeys.self)
        claims = try values.decodeIfPresent([String].self, forKey: .claims)
        logins = try values.decodeIfPresent([String].self, forKey: .logins)
        roles = try values.decodeIfPresent([Roles].self, forKey: .roles)
        hoTen = try values.decodeIfPresent(String.self, forKey: .hoTen)
        diaChi = try values.decodeIfPresent(String.self, forKey: .diaChi)
        imageLink = try values.decodeIfPresent(String.self, forKey: .imageLink)
        tenTaiKhoan = try values.decodeIfPresent(String.self, forKey: .tenTaiKhoan)
        email = try values.decodeIfPresent(String.self, forKey: .email)
        phoneNumber = try values.decodeIfPresent(String.self, forKey: .phoneNumber)
        id = try values.decodeIfPresent(String.self, forKey: .id)
		userName = try values.decodeIfPresent(String.self, forKey: .userName)
	}

}
