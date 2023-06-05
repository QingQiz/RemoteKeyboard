## Remote Keyboard

这个项目是用来将手机或PAD作为控制器来玩 osu 等音游的室友友好型项目 (windows特供)

### 用法

1. git clone ....
2. cd RemoteKeyboard/RemoteKeyboard
3. dotnet run
4. 在你的手机或PAD上打开浏览器，输入 http://ip-of-your-pc:3000
5. 玩

你可以修改 wwwroot/src/App.vue 中的 keys 来改键的数量

### 性能

1. 网络延迟
   - 局域网延迟: 4~7.5ms
   - 反向usb网络共享: 3-5ms
2. 按键延迟
    - 几乎为0
