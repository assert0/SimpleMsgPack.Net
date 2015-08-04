using SimpleMsgPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMsgPackTester
{
    class Program
    {
        static void Main(string[] args)
        {

            //MsgPack simp = new MsgPack();
            //simp.DecodeFromFile("E:\\1.msgpack");
            //Console.WriteLine(simp.ForcePathObject("User.DB.System.DUID").AsInteger);
            //Console.ReadLine();


            MsgPack msgpack = new MsgPack();
            msgpack.ForcePathObject("p.name").AsString = "张三";
            msgpack.ForcePathObject("p.age").AsInteger = 25;
            msgpack.ForcePathObject("p.datas").AsArray.Add(90);
            msgpack.ForcePathObject("p.datas").AsArray.Add(80);
            msgpack.ForcePathObject("p.datas").AsArray.Add("李四");
            msgpack.ForcePathObject("p.datas").AsArray.Add(Math.PI);
            msgpack.ForcePathObject("Game.iGameID").AsInteger = -1;
            msgpack.ForcePathObject("p.maxint64").AsUInt64 = Int64.MaxValue;
            msgpack.ForcePathObject("p.maxuint64").AsUInt64 = UInt64.MaxValue;
            msgpack.ForcePathObject("p.maxsingle").AsFloat = Single.MaxValue;

            // 可以直接打包文件数据
            // msgpack.ForcePathObject("p.filedata").LoadFileAsBytes("C:\\a.png");

            // 打包成msgPack协议格式数据
            byte[] packData = msgpack.Encode2Bytes();

            //Console.WriteLine("msgpack序列化数据:\n{0}", BytesTools.BytesAsHexString(packData));

            MsgPack unpack_msgpack = new MsgPack();
            // 从msgPack协议格式数据中还原
            unpack_msgpack.DecodeFromBytes(packData);

            System.Console.WriteLine("name:{0}, age:{1}",
                  unpack_msgpack.ForcePathObject("p.name").AsString,
                  unpack_msgpack.ForcePathObject("p.age").AsInteger);

            Console.WriteLine("==================================");
            System.Console.WriteLine("use index property, Length{0}:{1}",
                  unpack_msgpack.ForcePathObject("p.datas").AsArray.Length,
                  unpack_msgpack.ForcePathObject("p.datas").AsArray[0].AsString
                  );

            Console.WriteLine("==================================");
            Console.WriteLine("use foreach statement:");
            foreach (MsgPack item in unpack_msgpack.ForcePathObject("p.datas"))
            {
                Console.WriteLine(item.AsString);
            }

            Console.WriteLine(unpack_msgpack.ForcePathObject("Game.iGameID").AsInteger);

            Console.WriteLine(unpack_msgpack.ForcePathObject("p.maxint64").AsInteger);

            Console.WriteLine(unpack_msgpack.ForcePathObject("p.maxuint64").AsUInt64);

            try
            {
                Console.WriteLine(unpack_msgpack.ForcePathObject("p.maxuint64").AsInteger);
            }
            catch (OverflowException e) { Console.WriteLine(e.Message); }

            try
            {
                Console.WriteLine(unpack_msgpack.ForcePathObject("Game.iGameID").AsUInt64);
            }
            catch (OverflowException e) { Console.WriteLine(e.Message); }
            // unpack filedata 
            //unpack_msgpack.ForcePathObject("p.filedata").SaveBytesToFile("C:\\b.png");
            Console.Read();
        }
    }
}
