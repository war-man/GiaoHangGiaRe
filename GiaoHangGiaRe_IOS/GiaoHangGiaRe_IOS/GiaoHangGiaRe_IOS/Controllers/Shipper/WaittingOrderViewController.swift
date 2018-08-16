//
//  WaittingOrderViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/26/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire

class WaittingOrderViewController: UIViewController, UITableViewDelegate, UITableViewDataSource {
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return listDonHang.count
    }

    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "DonHangChoCell", for: indexPath) as! DonHangCellCustomTableViewCell
        cell.btnChiTiet.addTarget(self, action: #selector(self.btnChiTiet(sender:)), for: UIControlEvents.touchUpInside)
        cell.btnChiTiet.tag = indexPath.row
        cell.lblDiaChiDen.text = listDonHang[indexPath.row].diaChiNhan
        return cell
    }
    @objc func btnChiTiet (sender: UIButton){
        //alertMessager(title: "\(sender.tag)", message: "2")
        let vc = self.storyboard?.instantiateViewController(withIdentifier: "DonHangDetailsViewController") as! DonHangDetailsViewController
        vc.MaDonHang = sender.tag
        self.navigationController?.pushViewController( vc , animated: true)
    }
    @IBOutlet weak var tableDonHangCho: UITableView!
    var listDonHang : [DonHangList] = []
    override func viewDidLoad() {
        super.viewDidLoad()
        tableDonHangCho.delegate = self
        tableDonHangCho.dataSource = self
        getDonHang()
        // Do any additional setup after loading the view.
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        if segue.identifier == "registerSegue"{
            let des = segue.destination as? DonHangDetailsViewController
//            des?.delegate = self
        }
        
    }
    private func getDonHang() {
        let token = UserDefaults.standard.object(forKey: "access_token")
        let host = "http://giaohanggiare.gearhostpreview.com/"
        let params = [
            "size": 15]
        let header: HTTPHeaders = ["Authorization":token as! String]
        
        Alamofire.request(host+"api/donhang/get-all", method: .post, parameters: params, encoding: URLEncoding.httpBody, headers: header).responseData { (response) in
            
            if let data = response.result.value {
                let list = try? JSONDecoder().decode(DonHang.self, from: data)
                self.listDonHang = (list?.list)!
                DispatchQueue.main.async {
                    self.tableDonHangCho.reloadData()
                }
            }
        }
        
//        Alamofire.request(host+"api/donhang/get-all", method: .post, parameters: params, encoding: URLEncoding.httpBody, headers: header).responseJSON { (response) in
//
//            if let jsonString = response.value as? String {
//
//                print(jsonString)
//            }
//        }
        /*
        Alamofire.request(host+"api/donhang/get-all", method: .post, parameters: params, encoding: URLEncoding.httpBody, headers: header).responseJSON { response in
            switch(response.result) {
            case .success(_):
                if response.result.value != nil{
                    if let result = response.result.value {
                        let JSON = result as! NSDictionary
                        JSON.
//                        self.listDonHang = JSON["list"]! as! [DonHang]
                        
                        self.listDonHang = JSONDecoder().decode([DonHang].self, from: <#T##Data#>)
                        for (key,value) in JSON{
                            print(key)
                            print(value)
                        }
                        
                        self.tableDonHangCho.reloadData()
                        DispatchQueue.main.async {
                            self.tableDonHangCho.reloadData()
                        }
                    }
                }else{
                    
                }
            case .failure(_):
                self.alertMessager(title: "Kết nối thất bại", message: "Hãy thử lại")
                break
            }
        }
 */
    }
}
