//
//  HistoryOrderViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 9/9/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire

class HistoryOrderViewController: UIViewController, UITableViewDelegate, UITableViewDataSource {
    var donhangList: [Json4Swift_Base] = []
    @IBOutlet weak var tableViewHistoryOrder: UITableView!
    override func viewDidLoad() {
        tableViewHistoryOrder.delegate = self
        tableViewHistoryOrder.dataSource = self
        getHistoryOrder()
        super.viewDidLoad()
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }
    func getHistoryOrder() {
        let token = UserDefaults.standard.object(forKey: "access_token")
        let host = "http://giaohanggiare.gearhostpreview.com/"
        let header: HTTPHeaders = ["Authorization":token as! String]
        
        Alamofire.request(host+"api/donhang/get-history-shipper", method: .get, encoding: URLEncoding.httpBody, headers: header).responseData { (response) in
            if response.result.isSuccess{
                if let data = response.result.value {
                    let base = try? JSONDecoder().decode([Json4Swift_Base].self, from: data)
                    self.donhangList = base!;
                    DispatchQueue.main.async {
                        self.tableViewHistoryOrder.reloadData()
                    }
                }
            }
        }
    }
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return donhangList.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "HistoryOrderCell", for: indexPath) as! ShipperOrderCell
        return cell
    }
}
