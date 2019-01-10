//
//  SqlLiteViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/24/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import FMDB

class SqlLiteViewController: UIViewController {

    @IBOutlet weak var tfName: UITextField!
    @IBOutlet weak var tfPhone: UITextField!
    @IBOutlet weak var tfAddress: UITextField!
    @IBOutlet weak var btnSave: UIButton!
    @IBOutlet weak var btnFind: UIButton!
    
    var fileManager: FileManager?
    override func viewDidLoad() {
        super.viewDidLoad()
        initLocalDB()
        // Do any additional setup after loading the view, typically from a nib.
        
    }
     var dbPath: String = ""
    func initLocalDB(){
        let fileManager = FileManager.default
        let documentPath = fileManager.urls(for: .documentDirectory, in: .userDomainMask)
   
        if !fileManager.fileExists(atPath: dbPath){
            dbPath = (documentPath.first?.appendingPathComponent("giaohanggiare.db").path)!
            print(dbPath);
            let db = FMDatabase(path: dbPath)
            if db.open(){
                let sql_command = "CREATE TABLE IF NOT EXISTS contacts (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, address TEXT, phone TEXT)"
                if !db.executeStatements(sql_command){
                    print(db.lastError())
                }else{
                    print(db.lastError())
                }
            }else{
                print(db.lastError())
            }
        }else{
            dbPath = (documentPath.first?.appendingPathComponent("giaohanggiare.db").path)!
            print(dbPath);
             let db = FMDatabase(path: dbPath)
            if db.open(){
                let sql_command = "CREATE TABLE contacs IF NOT EXISTS (id INTERGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, address TEXT, phone TEXT)"
                if !db.executeStatements(sql_command){
                    print(db.lastError())
                }else{
                    print(db.lastError())
                }
                db.close()
            }else{
                print(db.lastError())
            }
        }
    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    func emptyInput() {
        tfName.text=""
        tfPhone.text=""
        tfAddress.text=""
    }
    @IBAction func btnSave_Clicj(_ sender: Any) {
        let sql_command = "INSERT INTO `contacts` (`name`, `address`, `phone`) VALUES ('\(tfName.text!)','\(tfAddress.text!)','\(tfPhone.text!)')"
        let db = FMDatabase(path: dbPath)
        if db.open(){
            if !db.executeStatements(sql_command){
                print(db.lastError())
            }else{
                emptyInput()
                db.close()
            }
        }else{
            print(db.lastError())
        }
    }
    
    @IBAction func btnFind_Click(_ sender: Any) {
        let db = FMDatabase(path: dbPath)
        if db.open(){
            let sql_command = "a"
//            let resaut = db.executeQuery(sql_command, values: nil)
            db.close()
        }else{
            print(db.lastError())
        }
    }
    

}
