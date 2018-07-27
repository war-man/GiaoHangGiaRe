//
//  RegisterViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/27/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit

class RegisterViewController: UIViewController {

    @IBOutlet weak var btnBack: UIButton!
    @IBOutlet weak var btnAvatar: UIButton!
    @IBOutlet weak var btnDangKy: UIButton!
    override func viewDidLoad() {
        super.viewDidLoad()
        btnAvatar.layer.cornerRadius = btnAvatar.frame.size.width / 2
        btnAvatar.layer.masksToBounds = true
        btnDangKy.layer.cornerRadius = 5
        // Do any additional setup after loading the view.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    

    @IBAction func btnBackClicked(_ sender: Any) {
        self.navigationController?.popViewController(animated: true)
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
