//
//  CreateOrderViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/26/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit

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
    
    @IBOutlet weak var btnSubmit: UIButton!
    var listKienHang: [KienHang] = []
    override func viewDidLoad() {
        btnTaoKienHang.layer.cornerRadius = btnTaoKienHang.frame.size.width / 2
        btnTaoKienHang.layer.masksToBounds = true
        tableKienHang.delegate = self
        tableKienHang.dataSource = self
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
        //check so luong kien hang
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
