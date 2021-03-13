
import websockets
import asyncio


async def echo(ws, path):
    msg = await ws.recv()
    print("Received message from client: " + msg)
    
    await ws.send(msg)


start_server = websockets.serve(echo, "localhost", 7890)

asyncio.get_event_loop().run_until_complete(start_server)
asyncio.get_event_loop().run_forever()