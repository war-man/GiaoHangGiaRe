//
//  CreateKienHangViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/26/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit

class CreateKienHangViewController: UIViewController,UIImagePickerControllerDelegate, UINavigationControllerDelegate {
    
    @IBOutlet weak var btnBack: UIButton!
    @IBOutlet weak var imgViewKienHang: UIImageView!
    @IBOutlet weak var btnChoseImage: UIButton!
    
    var imagePickerCtrl: UIImagePickerController?
    override func viewDidLoad() {
        super.viewDidLoad()

        // Do any additional setup after loading the view.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
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
    
    @IBAction func btnBackClicked(_ sender: Any) {
        self.dismiss(animated: true, completion: nil)
    }
    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destinationViewController.
        // Pass the selected object to the new view controller.
    }
    */

}
