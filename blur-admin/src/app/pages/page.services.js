/**
 * @author v.lugovsky
 * created on 03.05.2016
 */
(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages')
        .factory('GetUserAPI', GetUserAPI);
  
    /** @ngInject */
    function GetUserAPI($http,$rootScope,localStorage) {
        
        var host='http://localhost:8065/api/';
        var token ;
        var access_token;

         //get-all TaiKhKhoan
        var user_get_all = function(page,size) {

            token =localStorage.getObject('token');
            if(token==null)
                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;
            
            result = $http.get(host+'taikhoan/get-all?page='+page+'&size='+size, {

                headers: {

                    "Authorization": access_token
                }

            }).success(function(data){

              result = data;

            }).error(function(){

            });

            return result;

        };
        //get-current user TaiKhoan
        var user_current_user = function() {
            
            token =localStorage.getObject('token');

            if(token==null)

                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;

            result = $http.get(host+'taikhoan/get-current-user', {
                    
                    headers: {

                        "Authorization": access_token
                    }
                    
                }).success(function(data){
                    
                    result = data;
                    

                }).error(function(){

                });

                return result;;

        };
        //get-by-id TaiKhoan
        var user_getby_id = function(id) {

            token =localStorage.getObject('token');

            if(token==null)

                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;
    
            result = $http.get(host+'taikhoan/get-by-id?id='+id.id, {
                    
                    headers: {

                        "Authorization": access_token
                    }
                    
                }).success(function(data){
                    
                    result = data;
                   

                }).error(function(){

                });

                return result;;

        };

        //update     
        var user_update = function(input){
            
        token =localStorage.getObject('token');

            if(token==null)
            
                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;

            var url=host+'taikhoan/update';

            var data=input;

            result = $http.put(url, data, {
                
                headers: {

                    "Authorization": access_token
                }
                
            })
            .success(function (data, status) {

                result=data,status;
                //alert(result);

            })

            .error(function (data, status) {

            });

            return result;
            
        }

        //craete TaiKhoan
        var user_create = function(input){

            token =localStorage.getObject('token');

            if(token==null)
            
                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;

            var url=host+'taikhoan/create';

            var data=input;

            result = $http.post(url, data, {
                
                headers: {

                    "Authorization": access_token
                }
                
            })
            .success(function (Response) {

                result=Response;

            })

            .error(function (data, status,Errors) {

            });

            return result;
            
        }

        //delete TaiKhoan
        var user_delete = function(id){
            
            token =localStorage.getObject('token');

            if(token==null)
            
                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;

            var url=host+'taikhoan/delete?id='+id;


            result = $http.delete(url, {
                
                headers: {          
                    "Authorization": access_token
                }
                
            })
            .success(function (data, status) {


            })

            .error(function (data, status) {

            });

            return result;
            
        }

        //tao access_token = login taikoan
        var user_login = function(input){

            var result=null;

            var url='http://localhost:8065/token';
            
            var data=input;
            result = $http.post(url, data,
                {headers: { 'Content-Type': 'application/x-www-form-urlencoded' }})
            .success(function (data, status) {

                result=data,status;

            })

            .error(function (data, status) {

            });
            
            return result;

        }

        return {

            user_get_all: user_get_all,

            user_getby_id: user_getby_id,

            user_create : user_create,

            user_login :user_login,

            user_delete : user_delete,

            user_update : user_update,
            user_current_user:user_current_user
        };
    }

    //Services cho Lich Su
    angular.module('BlurAdmin.pages')
    .factory('GetLichSuAPI', GetLichSuAPI);

    /** @ngInject */
    function GetLichSuAPI($http,$rootScope,localStorage) {
        var host='http://localhost:8065/api/';
        var token ;
        var access_token
        
        //get-all Lich Su
        var lichsu_get_all = function(page,size) {

            token =localStorage.getObject('token');
            
            if(token==null)
            
                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;
            
            result = $http.get(host+'lichsu/get-all?page='+page+'&size='+size, {

                headers: {

                    "Authorization": access_token
                }

            }).success(function(data){

                result = data;

            }).error(function(){
                alert('<strong>Warning!</strong> Better check yourself, you <a href class="alert-link">not looking too good</a>.');
            });

            return result;

        };

        return {

                lichsu_get_all: lichsu_get_all,

            };
    }

    //Services cho Role
    angular.module('BlurAdmin.pages')
    .factory('GetRoleAPI', GetRoleAPI);

    /** @ngInject */
    function GetRoleAPI($http,$rootScope,localStorage) {

        var host='http://localhost:8065/api/';
        var token ;
        var access_token;

        // var host='http://localhost:8195/api/';
        
        // var access_token='bearer 4pPcs8BjS8etQVFMk3rTDccd2w41P8KC-nKUMtCaf73bKQMX0ZdlqtGStdNgrBJzzEe_MJF1k_UhcnCPoHAjWYyiOComSKDDi6cLs0xq51BmkkSj47uy_4ozLdQDuvci4HfVZLwd7gCMLD3ZnJ65bnh2FPm9yUaL_4jJ-0lyYvFOEGNvSSy1Lip6F1zLMDOrnrSvRmtRse_QSdPrRMVeCwyr9xuHGPFBIwSj2jkNBm5QYYU6C645Ndzil_Bj3HI8BH42kDz8HvPohwY5-rF7afIuY1o112mvYnc65WVy7zAwP3dLEJE64sLe1HpR9h-oaEI6L1mncC-miwXx-B2mJyF8Qo-0XYTwz6LqVoniFeBuS4f_uTzeHLhjOmUj7MoIvBR_nCVYmgdMtUHuy15c6TPIHovakL-QGAUIgyoOQLCwYOlMZMKLSW58sokrK3k1F-Zyp9fI0Zd-QLWCnYl2sXYNAF-ca8vurInEUvOKfV0';

            //get-all Role
        var role_get_all = function(page,size) {

            token =localStorage.getObject('token');
            
            if(token==null)
            
                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;
            
            result = $http.get(host+'role/get-all?page='+page+'&size='+size, {

                headers: {

                    "Authorization": access_token
                }

            }).success(function(data){

                result = data;

            }).error(function(){

            });

            return result;

        };


        //craete Role
        var role_create = function(input){
            
            token =localStorage.getObject('token');
            
            if(token==null)
            
                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;

            var url=host+'role/create';

            var data=input;

            result = $http.post(url, data, {
                
                headers: {

                    "Authorization": access_token
                }
                
            })
            .success(function (data, status) {

                result=data,status;

            })

            .error(function (data, status) {

            });

            return result;
            
        }

        //get-by-id Role
        var role_getby_id = function(id) {
            
            token =localStorage.getObject('token');

            if(token==null)

                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;
    
            result = $http.get(host+'role/get-by-id?id='+id.id, {
                    
                    headers: {

                        "Authorization": access_token
                    }
                    
                }).success(function(data){
                    
                    result = data;
                    

                }).error(function(){

                });

                return result;;

        };
        
        //Update Role
        var role_update = function(input) {
            
            token =localStorage.getObject('token');
            
            if(token==null)
            
                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;

            var url=host+'role/update';

            var data=input;

            result = $http.put(url, data, {
                
                headers: {

                    "Authorization": access_token
                }
                
            })
            .success(function (data, status) {

                result=data,status;

            })

            .error(function (data, status) {

            });

            return result;
    
            };

        //delete Role
        var role_delete = function(id){
            
            token =localStorage.getObject('token');

            if(token==null)
            
                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;

            var url=host+'role/delete?id='+id;


            result = $http.delete(url, {
                
                headers: {          
                    "Authorization": access_token
                }
                
            })
            .success(function (data, status) {


            })

            .error(function (data, status) {

            });

            return result;
            
        }

        return {

                role_get_all: role_get_all,

                role_create:role_create,

                role_getby_id:role_getby_id,

                role_update:role_update,

                role_delete:role_delete

            };
    }

//Services cho BangGia
angular.module('BlurAdmin.pages')
.factory('GetBangGiaAPI', GetBangGiaAPI);

/** @ngInject */
function GetBangGiaAPI($http,$rootScope,localStorage) {

    var host='http://localhost:8065/api/';
    var token ;
    var access_token; 

    //get-all BangGia
    var banggia_get_all = function(page,size) {
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;
        
        result = $http.get(host+'banggia/get-all?page='+page+'&size='+size, {

            headers: {

                "Authorization": access_token
            }

        }).success(function(data){

            result = data;

        }).error(function(){

        });

        return result;

    };

    //craete BangGia
    var banggia_create = function(input){
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'banggia/create';

        var data=input;

        result = $http.post(url, data, {
            
            headers: {

                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {

            result=data,status;

        })

        .error(function (data, status) {

        });

        return result;
        
    }

    //delete BangGia
        var banggia_delete = function(id){
            
        token =localStorage.getObject('token');

        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'banggia/delete?id='+id;


        result = $http.delete(url, {
            
            headers: {          
                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {


        })

        .error(function (data, status) {

        });

        return result;
        
    }

    //Update BangGia
    var banggia_update = function(input) {
        
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'banggia/update';

        var data=input;

        result = $http.put(url, data, {
            
            headers: {

                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {

            result=data,status;

        })

        .error(function (data, status) {

        });

        return result;

        };

        //get-by-id BangGia
        var banggia_getby_id = function(id) {
            
            token =localStorage.getObject('token');

            if(token==null)

                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;
    
            result = $http.get(host+'banggia/get-by-id?id='+id.id, {
                    
                    headers: {

                        "Authorization": access_token
                    }
                    
                }).success(function(data){
                    
                    result = data;
                    

                }).error(function(){

                });

                return result;;

        };

    return {

                banggia_get_all: banggia_get_all,

                banggia_create: banggia_create,

                banggia_delete:banggia_delete,

                banggia_update:banggia_update,

                banggia_getby_id:banggia_getby_id

        };
}

//Services cho KhachHang
angular.module('BlurAdmin.pages')
.factory('GetKhachHangAPI', GetKhachHangAPI);

/** @ngInject */
function GetKhachHangAPI($http,$rootScope,localStorage) {

    var host='http://localhost:8065/api/';
    var token ;
    var access_token; 

    //get-all KhachHang
    var khachhang_get_all = function(page,size) {
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;
        
        result = $http.get(host+'khachhang/get-all?page='+page+'&size='+size, {

            headers: {

                "Authorization": access_token
            }

        }).success(function(data){

            result = data;

        }).error(function(){

        });

        return result;

    };

    //craete KhachHang
    var khachhang_create = function(input){
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'khachhang/create';

        var data=input;

        result = $http.post(url, data, {
            
            headers: {

                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {

            result=data,status;

        })

        .error(function (data, status) {

        });

        return result;
        
    }

    //delete KhachHang
        var khachhang_delete = function(id){
            
        token =localStorage.getObject('token');

        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'khachhang/delete?id='+id;


        result = $http.delete(url, {
            
            headers: {          
                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {


        })

        .error(function (data, status) {

        });

        return result;
        
    }

    //Update KhachHang
    var khachhang_update = function(input) {
        
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'khachhang/update';

        var data=input;

        result = $http.put(url, data, {
            
            headers: {

                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {

            result=data,status;

        })

        .error(function (data, status) {

        });

        return result;

        };

        //get-by-id KhachHang
        var khachhang_getby_id = function(id) {
            
            token =localStorage.getObject('token');

            if(token==null)

                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;
    
            result = $http.get(host+'khachhang/get-by-id?id='+id.id, {
                    
                    headers: {

                        "Authorization": access_token
                    }
                    
                }).success(function(data){
                    
                    result = data;
                    

                }).error(function(){

                });

                return result;;

        };

    return {

                khachhang_get_all: khachhang_get_all,

                khachhang_create: khachhang_create,

                khachhang_delete:khachhang_delete,

                khachhang_update:khachhang_update,

                khachhang_getby_id:khachhang_getby_id

        };
}

//Services cho NhanVien
angular.module('BlurAdmin.pages')
.factory('GetNhanVienAPI', GetNhanVienAPI);

/** @ngInject */
function GetNhanVienAPI($http,$rootScope,localStorage) {

    var host='http://localhost:8065/api/';
    var token ;
    var access_token; 

    //get-all NhanVien
    var nhanvien_get_all = function(page,size) {
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;
        
        result = $http.get(host+'nhanvien/get-all?page='+page+'&size='+size, {

            headers: {

                "Authorization": access_token
            }

        }).success(function(data){

            result = data;

        }).error(function(){

        });

        return result;

    };

    //craete NhanVien
    var nhanvien_create = function(input){
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'nhanvien/create';

        var data=input;

        result = $http.post(url, data, {
            
            headers: {

                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {

            result=data,status;

        })

        .error(function (data, status) {

        });

        return result;
        
    }

    //delete NhanVien
        var nhanvien_delete = function(id){
            
        token =localStorage.getObject('token');

        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'nhanvien/delete?id='+id;


        result = $http.delete(url, {
            
            headers: {          
                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {


        })

        .error(function (data, status) {

        });

        return result;
        
    }

    //Update NhanVien
    var nhanvien_update = function(input) {
        
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'nhanvien/update';

        var data=input;

        result = $http.put(url, data, {
            
            headers: {

                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {

            result=data,status;

        })

        .error(function (data, status) {

        });

        return result;

        };

        //get-by-id NhanVien
        var nhanvien_getby_id = function(id) {
            
            token =localStorage.getObject('token');

            if(token==null)

                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;
    
            result = $http.get(host+'nhanvien/get-by-id?id='+id.id, {
                    
                    headers: {

                        "Authorization": access_token
                    }
                    
                }).success(function(data){
                    
                    result = data;
                    

                }).error(function(){

                });

                return result;;

        };

    return {

                nhanvien_get_all: nhanvien_get_all,

                nhanvien_create: nhanvien_create,

                nhanvien_delete:nhanvien_delete,

                nhanvien_update:nhanvien_update,

                nhanvien_getby_id:nhanvien_getby_id

        };
    }

//Services cho No
angular.module('BlurAdmin.pages')
.factory('GetNoAPI', GetNoAPI);

/** @ngInject */
function GetNoAPI($http,$rootScope,localStorage) {

    var host='http://localhost:8065/api/';
    var token ;
    var access_token; 

    //get-all NhanVien
    var no_get_all = function(page,size) {
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;
        
        result = $http.get(host+'no/get-all?page='+page+'&size='+size, {

            headers: {

                "Authorization": access_token
            }

        }).success(function(data){

            result = data;

        }).error(function(){

        });

        return result;

    };

    //craete No
    var no_create = function(input){
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'no/create';

        var data=input;

        result = $http.post(url, data, {
            
            headers: {

                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {

            result=data,status;

        })

        .error(function (data, status) {

        });

        return result;
        
    }

    //delete No
        var no_delete = function(id){
            
        token =localStorage.getObject('token');

        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'no/delete?id='+id;


        result = $http.delete(url, {
            
            headers: {          
                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {


        })

        .error(function (data, status) {

        });

        return result;
        
    }

    //Update No
    var no_update = function(input) {
        
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'no/update';

        var data=input;

        result = $http.put(url, data, {
            
            headers: {

                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {

            result=data,status;

        })

        .error(function (data, status) {

        });

        return result;

        };

        //get-by-id No
        var no_getby_id = function(id) {
            
            token =localStorage.getObject('token');

            if(token==null)

                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;
    
            result = $http.get(host+'no/get-by-id?id='+id.id, {
                    
                    headers: {

                        "Authorization": access_token
                    }
                    
                }).success(function(data){
                    
                    result = data;
                    

                }).error(function(){

                });

                return result;;

        };

    return {

                no_get_all: no_get_all,

                no_create: no_create,

                no_delete:no_delete,

                no_update:no_update,

                no_getby_id:no_getby_id

        };
    }


//Services cho HoaDon
angular.module('BlurAdmin.pages')
.factory('GetHoaDonAPI', GetHoaDonAPI);

/** @ngInject */
function GetHoaDonAPI($http,$rootScope,localStorage) {

    var host='http://localhost:8065/api/';
    var token ;
    var access_token; 

    //get-all HoaDon
    var hoadon_get_all = function(page,size) {
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;
        
        result = $http.get(host+'hoadon/get-all?page='+page+'&size='+size, {

            headers: {

                "Authorization": access_token
            }

        }).success(function(data){

            result = data;

        }).error(function(){

        });

        return result;

    };

    //craete hoadon
    var hoadon_create = function(input){
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'hoadon/create';

        var data=input;

        result = $http.post(url, data, {
            
            headers: {

                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {

            result=data,status;

        })

        .error(function (data, status) {

        });

        return result;
        
    }

    //delete hoadon
        var hoadon_delete = function(id){
            
        token =localStorage.getObject('token');

        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'hoadon/delete?id='+id;


        result = $http.delete(url, {
            
            headers: {          
                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {


        })

        .error(function (data, status) {

        });

        return result;
        
    }

    //Update hoadon
    var hoadon_update = function(input) {
        
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'hoadon/update';

        var data=input;

        result = $http.put(url, data, {
            
            headers: {

                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {

            result=data,status;

        })

        .error(function (data, status) {

        });

        return result;

        };

        //get-by-id Nohoadon

        var hoadon_getby_id = function(id) {
            
            token =localStorage.getObject('token');

            if(token==null)

                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;
    
            result = $http.get(host+'hoadon/get-by-id?id='+id.id, {
                    
                    headers: {

                        "Authorization": access_token
                    }
                    
                }).success(function(data){
                    
                    result = data;
                    

                }).error(function(){

                });

                return result;;

        };

    return {

        hoadon_get_all: hoadon_get_all,

        hoadon_create: hoadon_create,

        hoadon_delete:hoadon_delete,

        hoadon_update:hoadon_update,

        hoadon_getby_id:hoadon_getby_id

        };
    }
    
    //Services cho LoaiKH
angular.module('BlurAdmin.pages')
.factory('GetLoaiKHAPI', GetLoaiKHAPI);

/** @ngInject */
function GetLoaiKHAPI($http,$rootScope,localStorage) {

    var host='http://localhost:8065/api/';
    var token ;
    var access_token; 

    //get-all LoaiKH
    var loaikh_get_all = function(page,size) {
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;
        
        result = $http.get(host+'loaikh/get-all?page='+page+'&size='+size, {

            headers: {

                "Authorization": access_token
            }

        }).success(function(data){

            result = data;

        }).error(function(){

        });

        return result;

    };

    //craete loaikh
    var loaikh_create = function(input){
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'loaikh/create';

        var data=input;

        result = $http.post(url, data, {
            
            headers: {

                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {

            result=data,status;

        })

        .error(function (data, status) {

        });

        return result;
        
    }

    //delete loaikh
        var loaikh_delete = function(id){
            
        token =localStorage.getObject('token');

        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'loaikh/delete?id='+id;


        result = $http.delete(url, {
            
            headers: {          
                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {


        })

        .error(function (data, status) {

        });

        return result;
        
    }

    //Update loaikh
    var loaikh_update = function(input) {
        
        token =localStorage.getObject('token');
        
        if(token==null)
        
            token=$rootScope.token;

        access_token =token.token_type+' ' +token.access_token

        var result=null;

        var url=host+'loaikh/update';

        var data=input;

        result = $http.put(url, data, {
            
            headers: {

                "Authorization": access_token
            }
            
        })
        .success(function (data, status) {

            result=data,status;

        })

        .error(function (data, status) {

        });

        return result;

        };

        //get-by-id loaikh

        var loaikh_getby_id = function(id) {
            
            token =localStorage.getObject('token');

            if(token==null)

                token=$rootScope.token;

            access_token =token.token_type+' ' +token.access_token

            var result=null;
    
            result = $http.get(host+'loaikh/get-by-id?id='+id.id, {
                    
                    headers: {

                        "Authorization": access_token
                    }
                    
                }).success(function(data){
                    
                    result = data;
                    

                }).error(function(){

                });

                return result;;

        };

    return {

        loaikh_get_all: loaikh_get_all,

        loaikh_create: loaikh_create,

        loaikh_delete:loaikh_delete,

        loaikh_update:loaikh_update,

        loaikh_getby_id:loaikh_getby_id

        };
    }

})();
  


