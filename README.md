# CtrlNet.Util
CtrlNet.Util是一个.net core平台下的应用框架，由常用公共操作类(工具类)、第三方组件封装，第三方业务接口封装等组成。
#
使用：

Install-Package CtrlNet.Util

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
 2.2 3DES加密
```csharp
     //加密
    var str= 3DESEncrypt.Encrypt("123456");
    //解密
    3DESEncrypt.Decrypt("str");
```
3、Http
```csharp
//同步
var str= HttpMethods.Post("url", "jsondata");
var str= HttpMethods.Get("url");
//异步
Task<HttpResponseMessage>  msg=HttpMethods.PostAsync("url", "jsondata");
Task<HttpResponseMessage>  msg=HttpMethods.GetAsync("url");
```
4、Guid操作    
```csharp
//Guid操作
Guid  guid= CombUtil.NewComb();
DateTime date = CombUtil.GetDateFromComb(guid);
```
5、二进制序列化
```csharp
//二进制序列化
var binary = new BinarySerializer().Serialize("obj");
var obj= new BinarySerializer().Deserialize(binary);
```
6、Excel操作
```csharp
//导出
ExcelHelper.ExportBytes(new List<object>(),new string[1]);
//导入
ExcelHelper.ExcelImport<object>("filename");
```
