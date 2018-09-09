//
//  RegisterViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/27/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire

protocol RegisterViewControlleDelegete {
    func regiterSucecss(TenTaiKhoan: String)
}
class RegisterViewController: UIViewController, UIImagePickerControllerDelegate, UINavigationControllerDelegate {
    var delegate: RegisterViewControlleDelegete? = nil
    @IBOutlet weak var loadingSpinner: UIActivityIndicatorView!
    @IBOutlet weak var btnBack: UIButton!
    @IBOutlet weak var btnAvatar: UIButton!
    @IBOutlet weak var btnDangKy: UIButton!
    
    @IBOutlet weak var tfHoTen: UITextField!
    @IBOutlet weak var tfDiaChi: UITextField!
    @IBOutlet weak var tfEmail: UITextField!
    @IBOutlet weak var tfSoDienThoai: UITextField!
    @IBOutlet weak var tfTenTaiKhoan: UITextField!
    @IBOutlet weak var tfMatKhau: UITextField!
    @IBOutlet weak var tfXacNhanMatKhau: UITextField!
    
    
    var imagePickerCtrl: UIImagePickerController?
    override func viewDidLoad() {
        super.viewDidLoad()
        initUI()
        // Do any additional setup after loading the view.
    }
    override func viewWillAppear(_ animated: Bool) {
        
    }
    override func viewDidAppear(_ animated: Bool) {
        
    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    func initUI(){
        btnAvatar.layer.cornerRadius = btnAvatar.frame.size.width / 2
        btnAvatar.layer.masksToBounds = true
        btnDangKy.layer.cornerRadius = 5
    }
    
    //MASK: validationEmpty
    func validationEmpty() -> Bool {
        var valid: Bool = true
        if ((tfHoTen.text?.isEmpty))!{
            tfHoTen.attributedPlaceholder = NSAttributedString(string: "Hãy nhập họ tên", attributes: [NSAttributedStringKey.foregroundColor: UIColor.red] )
            valid = false
        }
        if ((tfDiaChi.text?.isEmpty))!{
            tfDiaChi.attributedPlaceholder = NSAttributedString(string:"Hãy nhập địa chỉ",attributes: [NSAttributedStringKey.foregroundColor: UIColor.red])
            valid = false
        }
        if ((tfEmail.text?.isEmpty))!{
            tfEmail.attributedPlaceholder = NSAttributedString(string:"Hãy nhập email ",attributes: [NSAttributedStringKey.foregroundColor: UIColor.red])
            valid = false
        }
        if ((tfSoDienThoai.text?.isEmpty))!{
            tfSoDienThoai.attributedPlaceholder = NSAttributedString(string: "Hãy nhập số điẹn thoại",attributes: [NSAttributedStringKey.foregroundColor: UIColor.red])
            valid = false
        }
        if ((tfTenTaiKhoan.text?.isEmpty))!{
            tfTenTaiKhoan.attributedPlaceholder = NSAttributedString(string: "Hãy nhập tên tài khoản",attributes: [NSAttributedStringKey.foregroundColor: UIColor.red])
            valid = false
        }
        if ((tfMatKhau.text?.isEmpty))!{
            tfMatKhau.attributedPlaceholder = NSAttributedString(string: "Hãy nhập Mật khẩu",attributes: [NSAttributedStringKey.foregroundColor: UIColor.red])
            valid = false
        }
        return valid
    }
    //MASK: validation email
    func isValidEmail(email:String?) -> Bool {
        guard email != nil else { return false }
        
        let regEx = "[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}"
        
        let pred = NSPredicate(format:"SELF MATCHES %@", regEx)
        return pred.evaluate(with: email)
    }
    //MASK: btnavatar clicked
    @IBAction func btnAvatarClicked(_ sender: Any) {
        imagePickerCtrl = UIImagePickerController()
        imagePickerCtrl?.delegate = self
        self.imagePickerCtrl?.allowsEditing =  true
        self.imagePickerCtrl?.videoQuality = UIImagePickerControllerQualityType(rawValue: 50)!
        let actionSheet = UIAlertController(title: "Chọn ảnh từ", message: "Hãy chọn cách mở", preferredStyle: .actionSheet)
        actionSheet.addAction(UIAlertAction(title: "Máy ảnh", style: .default, handler: { (acion: UIAlertAction) in
            if UIImagePickerController.isSourceTypeAvailable(.camera){
                self.imagePickerCtrl?.sourceType = .camera
                self.present(self.imagePickerCtrl!, animated: true, completion: nil)
            }else{
                
            }
        }))
        actionSheet.addAction(UIAlertAction(title: "Chọn từ album ảnh", style: .default, handler: { (acion: UIAlertAction) in
            self.imagePickerCtrl?.sourceType = .photoLibrary
            self.present(self.imagePickerCtrl!, animated: true, completion: nil)
        }))
        actionSheet.addAction(UIAlertAction(title: "Huỷ", style: .default, handler: nil))
        self.present(actionSheet, animated: true, completion: nil)
    }
    func imagePickerController(_ picker: UIImagePickerController, didFinishPickingMediaWithInfo info: [String : Any]) {
        let image = info[UIImagePickerControllerOriginalImage] as! UIImage
        btnAvatar.setImage(image, for: .normal)
        picker.dismiss(animated: true, completion: nil)
    }
    func imagePickerControllerDidCancel(_ picker: UIImagePickerController) {
        picker.dismiss(animated: true, completion: nil)
    }
    
    @IBAction func btnDangKyClicked(_ sender: Any) {
        loadingSpinner.startAnimating()
        UIApplication.shared.beginIgnoringInteractionEvents()
        if validationEmpty() == true{
            let host = "http://giaohanggiare.gearhostpreview.com/"
            var pic :NSData = UIImageJPEGRepresentation((btnAvatar.imageView?.image)!, 0.5) as! NSData
            let strBase64 = pic.base64EncodedString(options: NSData.Base64EncodingOptions(rawValue: 0))
            let params2 = ["base64": strBase64] as [String : Any]
            Alamofire.request(host+"api/image/upload", method: .post, parameters: params2, encoding: URLEncoding.httpBody).responseJSON { response in
                switch(response.result) {
                case .success(_):
                    let imagelink = response.result.value!
                    print(imagelink)
                    let params = ["HoTen" : self.tfHoTen.text!, "DiaChi":self.tfDiaChi.text!,
                                  "Email": self.tfEmail.text!, "SoDienThoai": self.tfSoDienThoai.text!,
                                  "TenTaiKhoan": self.tfTenTaiKhoan.text!, "Password": self.tfMatKhau.text!,
                                  "ImageLink": imagelink
                        ] as [String : Any]
                    Alamofire.request(host+"user/api/taikhoan/register", method: .post, parameters: params, encoding: JSONEncoding.default).responseJSON { response in
                        switch(response.result) {
                        case .success(_):
                            let res = response.result.value! as! NSDictionary
                            let succeeded = res.object(forKey:"Succeeded")
                            if succeeded as! Int == 1{
                                self.showToast(message: "Đăng ký thành công")
                                self.delegate?.regiterSucecss(TenTaiKhoan: self.tfTenTaiKhoan.text!)
                                self.loadingSpinner.stopAnimating()
                                UIApplication.shared.endIgnoringInteractionEvents()
                                self.navigationController?.popViewController(animated: true)
                            }else{
                                print(res)
                            }
                            break
                            
                        case .failure(_):
                            self.loadingSpinner.stopAnimating()
                            UIApplication.shared.endIgnoringInteractionEvents()
                            self.alertMessager(title: "Kết nối thất bại", message: "Hãy thử lại")
                            break
                        }
                    }
                    break
                    
                case .failure(_):
                    self.loadingSpinner.stopAnimating()
                    UIApplication.shared.endIgnoringInteractionEvents()
                    self.alertMessager(title: "Kết nối thất bại", message: "Hãy thử lại")
                    break
                }
            }
        }else{
            loadingSpinner.startAnimating()
        }
    }
    @IBAction func btnBack(_ sender: Any) {
        self.navigationController?.popViewController(animated: true)
    }
    
}
