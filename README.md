## Remote Keyboard

这个项目是用来将手机或PAD作为控制器来玩 osu 等音游的室友友好型项目 (windows特供)

### 依赖

- nodejs
- dotnet 7 (嫌高可以改 RemoteKeyboard.csproj 里的 TargetFramework)
- 在同一个局域网中的 `手机或PAD` 和 `电脑`
- [gnirehtet](https://github.com/Genymobile/gnirehtet) (可选，使用这个来创建反向usb网络共享，可以显著稳定延迟)

### 用法

1. git clone ....
2. cd RemoteKeyboard/RemoteKeyboard
3. dotnet run
4. 在你的手机或PAD上打开浏览器，输入 http://ip-of-your-pc:3000
5. 玩

你可以修改 wwwroot/src/App.vue 中的 keys 来改键的数量

### 性能

1. 网络延迟 (较为理想的网络环境，如：路由器在身边，反向usb网络共享)
   - 局域网延迟: 4~7.5ms
   - 反向usb网络共享: 3-5ms
2. 按键延迟
    - 几乎为0

### 常见问题


#### 我电脑的ip是哪个？

在命令行中输入 ipconfig，找到你的网卡的ip地址，结果比如
```
Ethernet adapter 以太网:

Connection-specific DNS Suffix  . :
Link-local IPv6 Address . . . . . : fe80::28e:722:1330:f1cb%18
IPv4 Address. . . . . . . . . . . : 192.168.31.2
Subnet Mask . . . . . . . . . . . : 255.255.255.0
Default Gateway . . . . . . . . . : 192.168.31.1
```
那你的ip就是 `192.168.31.2`

---

#### 报错: `error CS1617: /langversion 的选项“11”无效。使用 "/langversion:?" 列出支持的值。`

你的dotnet SDK版本太低了

嫌高可以调低 RemoteKeyboard.csproj 里的 LangVersion

---

#### 报错: `当前 .NET SDK 不支持将 .NET 7.0 设置为目标。请将 .NET 6.0 或更低版本设置为目标，或使用支持 .NET 7.0 的 .NET SDK 版本。`

你的dotnet SDK版本太低了

嫌高可以改 RemoteKeyboard.csproj 里的 TargetFramework