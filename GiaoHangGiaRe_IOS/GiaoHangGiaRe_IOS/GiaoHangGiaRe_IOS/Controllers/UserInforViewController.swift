//
//  UserInforViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/26/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit

class UserInforViewController: UIViewController {
    
    @IBOutlet weak var LoadingSpinner: UIActivityIndicatorView!
    override func viewDidLoad() {
        super.viewDidLoad()
        LoadingSpinner.startAnimating()
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
    
    
    /*
     // MARK: - Navigation
     
     // In a storyboard-based application, you will often want to do a little preparation before navigation
     override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
     // Get the new view controller using segue.destinationViewController.
     // Pass the selected object to the new view controller.
     }
     */
    
}
