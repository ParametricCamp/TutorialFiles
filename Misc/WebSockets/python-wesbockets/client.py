
import websockets
import asyncio

async def hello():
    url = "ws://127.0.0.1:7890"
    async with websockets.connect(url) as ws:
        await ws.send("Hello Server!")


async def listen():
    url = "ws://127.0.0.1:7890"

    async with websockets.connect(url) as ws:
        while True:
            msg = await ws.recv()
            print(msg)

asyncio.get_event_loop().run_until_complete(hello())
asyncio.get_event_loop().run_until_complete(listen())