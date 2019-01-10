//
//  CreateOrderViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/26/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire
import NVActivityIndicatorView

class CreateOrderViewController: UIViewController, TaoKienHangDelegate,UITableViewDelegate,UITableViewDataSource {
    @IBOutlet weak var tableKienHang: UITableView!
    @IBOutlet weak var btnTaoKienHang: UIButton!
    @IBOutlet weak var lblSoKienHang: UILabel!
    @IBOutlet weak var tfNguoiGui: UITextField!
    @IBOutlet weak var tfSoDienThoaiGui: UITextField!
    @IBOutlet weak var tfDiaChiGui: UITextField!
    
    @IBOutlet weak var tfNguoiNhan: UITextField!
    @IBOutlet weak var tfSoDienThoaiNhan: UITextField!
    @IBOutlet weak var tfDiaChiNhan: UITextField!
    @IBOutlet weak var tfGhiChu: UITextField!
    
    @IBOutlet weak var tfCod: UITextField!
    @IBOutlet weak var btnSubmit: UIButton!
    var listKienHang: [KienHang] = []
    var activityIndicatorView : NVActivityIndicatorView!
    var overlay : UIView?
    
    override func viewDidLoad() {
        tfNguoiGui.text = "qwe"
        tfSoDienThoaiGui.text = "12132"
        tfDiaChiGui.text = "qwe1"
        tfNguoiNhan.text = "qwe"
        tfSoDienThoaiNhan.text = "21321312"
        tfDiaChiNhan.text = "qwe"
        tfGhiChu.text = "qwe"
        tfCod.text = "12"
        
        btnTaoKienHang.layer.cornerRadius = btnTaoKienHang.frame.size.width / 2
        btnTaoKienHang.layer.masksToBounds = true
        tableKienHang.delegate = self
        tableKienHang.dataSource = self
        initLoadingUI()
        super.viewDidLoad()
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }

    @IBAction func btnTaoKienHang_Clicked(_ sender: Any) {
        
    }
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        if segue.identifier == "gotoCreateKH"{
            
            let des = segue.destination as? CreateKienHangViewController
            des?.ourDelegate = self as TaoKienHangDelegate
        }
    }
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return listKienHang.count
    }
    @IBAction func btnSubmitClicked(_ sender: Any) {

        //check input
        if listKienHang.count == 0{
            alertMessager(title: "Thông báo", message: "Hãy thêm kiện hàng.")
        }else{
            //Start Loading
            activityIndicatorView.startAnimating()
            view.addSubview(overlay!)
            
            let donhang: DonHangModel = DonHangModel(NguoiGui: tfNguoiGui.text!, SoDienThoaiNguoiGui: tfSoDienThoaiGui.text!, DiaChiGui: tfDiaChiGui.text!, NguoiNhan: tfNguoiNhan.text!, SoDienThoaiNguoiNhan: tfSoDienThoaiNhan.text!, DiaChiNhan: tfDiaChiNhan.text!, GhiChu: tfGhiChu.text!, cod: Int(tfCod.text!)!)
//            donhang.NguoiGui = tfNguoiGui.text!
//            donhang.SoDienThoaiGui = tfSoDienThoaiGui.text!
//            donhang.DiaChiGui = tfDiaChiGui.text!
//            donhang.NguoiNhan = tfNguoiNhan.text!
//            donhang.SoDienThoaiNhan = tfSoDienThoaiNhan.text!
//            donhang.DiaChiNhan = tfDiaChiNhan.text!
//            donhang.GhiChu = tfGhiChu.text!
//            donhang.cod = Int(tfCod.text!)!
            var _:CreateDonHang = CreateDonHang(kienHang:listKienHang, donHang: donhang)
            
            let token = UserDefaults.standard.object(forKey: "access_token")
            let headers: HTTPHeaders = ["Authorization":token as! String]
            var kienHangData: [[String: Any]] = []
            for item in listKienHang {
                kienHangData.append(item.toJSON()) 
            }
            print(kienHangData)
            let params = ["donHang" : donhang.toJSON(), "kienHang":kienHangData
                ] as [String : Any]
            Alamofire.request(root_host + "api/donhang/create", method: .post, parameters: params, headers:headers).responseJSON { response in
                switch(response.result) {
                case .success(_):
                    self.stopLoading()
                    print(response.result.value)
                    guard let respon = response.result.value else{
                        self.stopLoading()
                        return
                    }
//                    let res = respon as! NSDictionary
//
//                    let succeeded = res.object(forKey:"Succeeded")
//                    if succeeded as! Int == 1{
//                    }else{
//                        print(res)
//                    }
                    break

                case .failure(_):
                    self.stopLoading()
                    self.alertMessager(title: "Kết nối thất bại", message: "Hãy thử lại")
                    break
                }
            }
        }
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "KienHangViewCell", for: indexPath) as! KienHangViewCell
        cell.lblNoiDung.text = listKienHang[indexPath.row].NoiDung
        cell.lblMoTa.text = listKienHang[indexPath.row].MoTa
        cell.lblSoLuong.text = "\(listKienHang[indexPath.row].SoLuong)"
        cell.lblChieuDai.text = "\(listKienHang[indexPath.row].ChieuDai)"
        cell.lblChieuRong.text = "\(listKienHang[indexPath.row].ChieuRong)"
        cell.lblTrongLuong.text = "\(listKienHang[indexPath.row].TrongLuong)"
        return cell
    }
    
    func TaoKienHang(kienhang: KienHang) {
        listKienHang.append(kienhang)
        lblSoKienHang.text = "\(listKienHang.count)"
        tableKienHang.reloadData()
    }
}
extension CreateOrderViewController{
    func stopLoading() {
        //Stop Loading
        self.activityIndicatorView.stopAnimating()
        self.overlay?.removeFromSuperview()
    }
    func initLoadingUI() {
        let xAxis = self.view.center.x
        let yAxis = self.view.center.y
        let frame = CGRect(x: (xAxis - 25), y: (yAxis - 35), width: 50, height: 50)
        activityIndicatorView = NVActivityIndicatorView(frame: frame)
        activityIndicatorView.type = . ballClipRotate // add your type
        activityIndicatorView.color = UIColor.orange // add your color
        overlay = UIView(frame: view.frame)
        overlay?.backgroundColor = UIColor.black
        overlay?.alpha = 0.3
        self.view.addSubview(activityIndicatorView)
    }
}
