using Microsoft.AspNetCore.Mvc;
using WindowsInput;
using WindowsInput.Native;

namespace RemoteKeyboard.Controllers;

public class WebSocketController : ControllerBase
{
    private static readonly IKeyboardSimulator Simulator = new InputSimulator().Keyboard;

    private static readonly List<VirtualKeyCode> Keys = new()
    {
        VirtualKeyCode.VK_Q, VirtualKeyCode.VK_W, VirtualKeyCode.VK_E,
        VirtualKeyCode.VK_R, VirtualKeyCode.VK_T, VirtualKeyCode.VK_Y, VirtualKeyCode.VK_U,
        VirtualKeyCode.VK_I, VirtualKeyCode.VK_O, VirtualKeyCode.VK_P
    };

    [Route("/ws/{type:int}/{id:int}")]
    public async Task Get(int id, int type)
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var ws = await HttpContext.WebSockets.AcceptWebSocketAsync();

            var key    = Keys[id];
            var buffer = new byte[10];

            if (type == 0)
            {
                while (true)
                {
                    await ws.ReceiveAsync(buffer, new CancellationToken());
                    Simulator.KeyDown(key);

                    if (ws.CloseStatus.HasValue) break;
                }
            }
            else if (type == 1)
            {
                while (true)
                {
                    await ws.ReceiveAsync(buffer, new CancellationToken());
                    Simulator.KeyUp(key);

                    if (ws.CloseStatus.HasValue) break;
                }
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
    }
}