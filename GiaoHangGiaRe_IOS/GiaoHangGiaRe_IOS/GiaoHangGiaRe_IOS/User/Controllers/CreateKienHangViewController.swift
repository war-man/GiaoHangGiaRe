//
//  CreateKienHangViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/26/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
protocol TaoKienHangDelegate {
    func TaoKienHang(kienhang: KienHang)
}
class CreateKienHangViewController: UIViewController,UIImagePickerControllerDelegate, UINavigationControllerDelegate {
    
    @IBOutlet weak var btnBack: UIButton!
    @IBOutlet weak var imgViewKienHang: UIImageView!
    @IBOutlet weak var btnChoseImage: UIButton!
    @IBOutlet weak var btnTaoKienHang: UIButton!
    @IBOutlet weak var tfNoiDung: UITextField!
    @IBOutlet weak var tfChieuDai: UITextField!
    @IBOutlet weak var tfChieuRong: UITextField!
    @IBOutlet weak var tfTrongLuong: UITextField!
    @IBOutlet weak var tfSoLuong: UITextField!
    @IBOutlet weak var tfMoTa: UITextField!
    
    var ourDelegate: TaoKienHangDelegate? = nil
    var imagePickerCtrl: UIImagePickerController?
    override func viewDidLoad() {
        tfNoiDung.text = "Noi dung  2"
        tfChieuDai.text = "2"
        tfChieuRong.text = "3"
        tfTrongLuong.text = "12"
        tfSoLuong.text = "2"
        tfMoTa.text = "Mo ta 2"
        super.viewDidLoad()
    }
    
    @IBAction func btnChoseImage_Clicked(_ sender: Any) {
        imagePickerCtrl = UIImagePickerController()
        imagePickerCtrl?.delegate = self
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
        imgViewKienHang.image = image
        picker.dismiss(animated: true, completion: nil)
    }
    func imagePickerControllerDidCancel(_ picker: UIImagePickerController) {
        picker.dismiss(animated: true, completion: nil)
    }
    
    @IBAction func btnTaoKienHangClicked(_ sender: Any) {
        if validation() == true{
            
            let kh: KienHang = KienHang(NoiDung: tfNoiDung.text!, ChieuDai: Int(tfChieuDai.text!)!, ChieuRong: Int(tfChieuRong.text!)!, MoTa: tfMoTa.text!, TrongLuong: Int(tfTrongLuong.text!)!, SoLuong: Int(tfSoLuong.text!)!)
            self.ourDelegate?.TaoKienHang(kienhang: kh)
        }else{
        }
        self.dismiss(animated: true, completion: {
        })
    }
    @IBAction func btnBackClicked(_ sender: Any) {
        self.dismiss(animated: true, completion: {
        })
    }
    func validation()->Bool{
        if tfNoiDung.text == nil{
            return false
        }
        if tfChieuDai.text == nil{
            return false
        }
        if tfChieuRong.text == nil{
            return false
        }
        if tfTrongLuong.text == nil{
            return false
        }
        if tfSoLuong.text == nil{
            return false
        }
        if tfMoTa.text == nil{
            return false
        }
        return true
    }
}
