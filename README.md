# CtrlNet.Util
CtrlNet.Util is an application framework under.net core platform, which is composed of common operation class (tool class), third-party component encapsulation, third-party business interface encapsulation and so on.
#
使用：

Use：

```
Install-Package CtrlNet.Util
```
1. The current extended class includes
Normal type conversions (String, DateTime, Int, Bool, Decimal, Double)
Json serialization and deserialization
String verification, judgment, conversion of Chinese pinyin, etc
There are also some general validation judgments

2. Security

2.1 the DES encryption

```csharp

// encryption
Var encryptStr = DESEncrypt.Encrypt("XXXX");
// decryption
Var STR = DESEncrypt.Decrypt(encryptStr);

```

2.2  des encryption

```csharp
// encryption
Var str = _3DESEncrypt.Encrypt ("123456");
// decryption
_3DESEncrypt.Decrypt(str);
```

3. the Http

```csharp
// synchronize
Var str = HttpMethods.Post("url", "jsondata");
Var str = HttpMethods.Get("url");
// asynchronous
Task<HttpResponseMessage> msg = HttpMethods.PostAsync("url ", "jsondata");
Task<HttpResponseMessage> msg = HttpMethods.GetAsync("url ");
```

4. Guid operation

```csharp
//Guid operations
Guid Guid = CombUtil.NewComb();
DateTime date = CombUtil.GetDateFromComb(guid);
```

5. Binary serialization

```csharp
// binary serialization
Var binary = new BinarySerializer().Serialize("obj");
Var obj = new BinarySerializer().Deserialize(binary);
```

6. Excel operation

```csharp
//export
ExcelHelper.ExportBytes(new List<object>(),new string [1]).
// import
ExcelHelper.ExcelImport<object>("filename");
```

7. Add object mapping

```csharp
//deep copy
MapperExtensions.Clone<Test>(test1);
//object creation
MapperExtensions.Map<TDestination>(source);
//Object creation
MapperExtensions.Map<TSource,TDestination>(source);
```