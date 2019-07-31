# CtrlNet.Util
CtrlNet.Util是一个.net core平台下的应用框架，由常用公共操作类(工具类)、第三方组件封装，第三方业务接口封装等组成。
#
1、目前扩展类包括
    
    常规类型转换(String、DateTime、Int、Bool、Decimal、Double)
    Json序列化和反序列化
    String验证、判断、中文拼音的转换等
    还有一些常规的验证判断
2、Security
    
   2.1 DES加密
```csharp
            //加密
            var encryptStr= DESEncrypt.Encrypt("xxxx");
            //解密
            var str = DESEncrypt.Decrypt(encryptStr);
```
   2.2md5加密


