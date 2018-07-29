//
//  UserInforViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/26/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire

class UserInforViewController: UIViewController {
    
    @IBOutlet weak var LoadingSpinner: UIActivityIndicatorView!
    var userInfo: User?
    override func viewDidLoad() {
        super.viewDidLoad()
        LoadingSpinner.startAnimating()
        getUserInfo()
        self.LoadingSpinner.hidesWhenStopped = true
        DispatchQueue.main.asyncAfter(deadline: .now() + 2) {
            self.LoadingSpinner.stopAnimating()
            
        }
        // Do any additional setup after loading the view.
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    func getUserInfo() {
        let host = "http://127.0.0.1:8080/"
        let token = UserDefaults.standard.object(forKey: "access_token")
        let header: HTTPHeaders = ["Authorization":token as! String]
        Alamofire.request(host + "user/api/taikhoan/get-current-user", method: HTTPMethod.get, parameters: nil, encoding: JSONEncoding.default, headers: header).responseJSON { response in
            switch response.result {
            case .success:
                if response.result.value != nil{
                    print(response.result.value!)
                }
                break
            case .failure(let error):
                break
            }
        }
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
