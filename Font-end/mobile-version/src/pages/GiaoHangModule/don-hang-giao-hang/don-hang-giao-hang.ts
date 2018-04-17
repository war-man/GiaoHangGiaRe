import { Component } from '@angular/core';
//import { SignalrServiceProvider } from '../../../providers/signalr-service/signalr-service';
import { NavController, NavParams } from 'ionic-angular';
import { DonhangServicesProvider } from '../../../providers/donhang-services/donhang-services';


/**
 * Generated class for the DonHanGiaoHangPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@Component({
  selector: 'page-don-hang-giao-hang',
  templateUrl: 'don-hang-giao-hang.html',
})
export class DonHangGiaoHangPage {
  nick = '';
  message = '';
  messages: string[] = [];
  listDonHang: any;
  constructor(public navCtrl: NavController, public navParams: NavParams,
    public DonhangServices: DonhangServicesProvider) {
    this.DonhangServices.getAllDonHangShipper().then(res => {
      this.listDonHang = res.list;
      console.log(this.listDonHang);
    })
  }

  ngOnInit() {
    // this.SignalrProvider.startConnection();
  }
}
// C:\ProgramData\Oracle\Java\javapath;
// %SystemRoot%\system32;
// %SystemRoot%;
// %SystemRoot%\System32\Wbem;
// %SYSTEMROOT%\System32\WindowsPowerShell\v1.0\;
// %USERPROFILE%\.dnx\bin;
// C:\Program Files\Microsoft DNX\Dnvm\;
// C:\Program Files\Microsoft SQL Server\120\Tools\Binn\;
// c:\Program Files\Microsoft SQL Server\110\Tools\Binn\;
// c:\Program Files (x86)\Microsoft SQL Server\110\Tools\Binn\;
// c:\Program Files\Microsoft SQL Server\110\DTS\Binn\;
// c:\Program Files (x86)\Microsoft SQL Server\110\Tools\Binn\ManagementStudio\;
// c:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\PrivateAssemblies\;
// c:\Program Files (x86)\Microsoft SQL Server\110\DTS\Binn\;
// C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\130\Tools\Binn\;
// C:\Program Files (x86)\Microsoft SQL Server\140\Tools\Binn\;
// C:\Program Files\Microsoft SQL Server\140\Tools\Binn\;
// C:\Program Files\Microsoft SQL Server\140\DTS\Binn\;
// C:\Program Files\Git\cmd;
// C:\Program Files\nodejs\;C:\Program Files\dotnet\;
// C:\Program Files\Microsoft SQL Server\130\Tools\Binn\;
// C:\Program Files (x86)\Microsoft SQL Server\Client SDK\ODBC\130\Tools\Binn\;
// C:\Program Files (x86)\Microsoft SQL Server\140\DTS\Binn\;
// C:\Program Files (x86)\Microsoft SQL Server\140\Tools\Binn\ManagementStudio\