using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKC3_Init_scripts
{
    public partial class ROM
    {
        public List<Sprites> sprites;
        public List<byte> rom = new List<byte>();
        public byte[] backupRom;
        public string fileName;
        public bool loadROMSuccess = false;
        public bool saved = false;
        public static int seed = 0;
        public StoredData sd;
        public int maxFileNameLength = 80;
        public static string gameTitleAsString;
        public string path;
        public Stack<byte[]> backedupList = new Stack<byte[]>();
        public static string emuPath;
        public static string romPath = "test.smc";
        //public static string romPath = Global.romPath;
        public Dictionary<string, string> gameBGpointers = new Dictionary<string, string>();
        public Dictionary<string, string> gameObjpointers = new Dictionary<string, string>();
        public Dictionary<string, string> gameCustompointers = new Dictionary<string, string>();

        public int romVersion = 0;
        public int backupIndex = 0;
        public string backupFileName = "";
        private int maxBackupCount = 10;

        public ROM(StoredData sd)
        {
            this.sd = sd;
            sprites = Setup();
        }

        public void Load (string category = "Path") 
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "ROM file (*.smc;*.sfc)|*.smc;*.sfc";
            d.Title = "Select a proper DKC ROM";

            while (d.ShowDialog() == DialogResult.OK)
            {
                fileName = d.FileName;
                if (LoadROM(d.FileName, category))
                    break;
            }
        }
        public  bool LoadROM (string path, string category = "Path", bool  notHex = true)
        {

            // Refresh Ini
            sd.RefreshRbs();
            //Loading my file and displaying all my content.
            backupRom = File.ReadAllBytes(path);
            backupRom = backupRom.Skip(backupRom.Length == 0x400200 ? 0x200 : 0).ToArray();
            
            // As seen in header
            var gameTitle = new ArraySegment<byte>(backupRom, 0XFFC0, 21).ToArray();
            gameTitleAsString = GetTitleFromHeader(gameTitle);
            // Verify checksum
            //if (GetChecksum(backupRom) == 0x163e1202.ToString("x"))
            if (backupRom[0xffdb] == 0/* && (VerifyROM(gameTitle, "DONKEY KONG COUNTRY  "))*/)
            {

                // Copy backup to main
                RestoreFromBackup();
                loadROMSuccess = true;

                fileName = path;
                this.path = path;
                this.fileName = path;
                // Add to recents
                //sd.AddToRecents(path);

                // TODO add check for recents
                // Write to ini as recent
                if (notHex)
                {
                    sd.Write("File", category, path);
                    sd.SaveRbs();
                }

                backedupList = new Stack<byte[]>();
                var temp = new List<byte>();
                temp.AddRange(rom.ToArray());
                backedupList.Push(temp.ToArray());

                gameBGpointers = sd.ReadCategory(gameTitleAsString + "BG");
                gameObjpointers = sd.ReadCategory(gameTitleAsString + "Obj");
                gameCustompointers = sd.ReadCategory(gameTitleAsString + "Custom");


                System.IO.File.WriteAllBytes("Backup-Start.smc", rom.ToArray());

                ReadBackup();
                return true;
            }
            else
            {
                MessageBox.Show("Invalid file");
                return false;
            }

        }

        private void ReadBackup()
        {
        }

        public UInt16 Read8(Int32 address)
        {
            //address &= 0x3fffff;
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            return (UInt16)rom[address++];
        }
        public UInt16 Read8(ref Int32 address)
        {
            //address &= 0x3fffff;
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            return (UInt16)rom[address++];
        }
        public UInt16 Read16(Int32 address)
        {
            if (address == 0x400000)
            {

            }
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            if (address == 0x400000 || address > 0x3fefff)
            {

            }
            return (UInt16)(
                (rom[address++] << 0) |
                (rom[address++] << 8));
        }
        public UInt16 Read16(ref Int32 address)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            return (UInt16)(
                (rom[address++] << 0) |
                (rom[address++] << 8));
        }
        public UInt16 Read16LDA(Int32 address)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            address++;
            return (UInt16)(
                (rom[address++] << 0) |
                (rom[address++] << 8));
        }
        public UInt32 Read24(Int32 address)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            return (UInt32)(
                (rom[address++] << 0) |
                (rom[address++] << 8) |
                (rom[address++] << 16));
        }
        public UInt32 Read32(Int32 address)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            return (UInt32)(
                (rom[address++] << 0) |
                (rom[address++] << 8) |
                (rom[address++] << 16) |
                (rom[address++] << 24));
        }
        public string ReadString (int address, int size)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            string str = "";
            for (int i = 0; rom[address + i] != 0; i++)
            {
                str += (char)rom[address + i];
            }

            return str;
        }

        public byte[] ReadSubArray(Int32 address, int size, byte[] arr)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            return (new List<byte>(arr.ToList().GetRange(address, size)).ToArray());
        }
        public int[] ReadSubIntArray(Int32 address, int size, byte[] arr)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            byte[] temp = (new List<byte>(arr.ToList().GetRange(address, size)).ToArray());
            int[] @return = new int[temp.Length / 2];
            for (int i = 0; i < @return.Length; i++)
            {
                int num = (temp[i * 2] << 0) | (temp[i * 2 + 1] << 8);
                @return[i] = num;
            }
            return @return;
        }


        public void Write8(Int32 address, Int32 value)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            // Actually write
            rom[address++] = (byte)(value >> 0);

            //AddToBackupList(rom.ToArray());
        }
        public void Write8(ref Int32 address, Int32 value)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            rom[address++] = (byte)(value >> 0);
        }
        public void Write16(Int32 address, Int32 value, bool tm = false)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);

            // Actually write
            rom[address++] = (byte)(value >> 0);
            rom[address++] = (byte)(value >> 8);
        }
        public void Write16LDA(Int32 address, Int32 value)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            address++;
            // Actually write
            rom[address++] = (byte)(value >> 0);
            rom[address++] = (byte)(value >> 8);
        }
        public void Write16(ref Int32 address, Int32 value)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            // Actually write
            rom[address++] = (byte)(value >> 0);
            rom[address++] = (byte)(value >> 8);
            //AddToBackupList(rom.ToArray());
        }
        public void Write24(Int32 address, Int32 value)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            // Actually write
            rom[address++] = (byte)(value >> 0);
            rom[address++] = (byte)(value >> 8);
            rom[address++] = (byte)(value >> 16);
            //AddToBackupList(rom.ToArray());
        }
        public void Write32(Int32 address, Int32 value)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            // Actually write
            rom[address++] = (byte)(value >> 0);
            rom[address++] = (byte)(value >> 8);
            rom[address++] = (byte)(value >> 16);
            rom[address++] = (byte)(value >> 24);
        }

        public void WriteString(Int32 address, string str)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            foreach (var letter in str)
            {
                rom[address++] = (byte)(letter);
            }
            AddToBackupList(rom.ToArray());
        }
        public void WriteArrToROM(byte[] arr, int destIndex)
        {
            destIndex &= (destIndex > 0x7fffff ? 0x3fffff : 0xffffff);
            int i = destIndex;
            int index = 0;
            int size = arr.Length;
            while (index < size)
            {
                Write8(i++, arr[index++]);
            }
        }
        public void WriteArrOfIntsToROM(int[] arr, int destIndex)
        {
            destIndex &= (destIndex > 0x7fffff ? 0x3fffff : 0xffffff);
            int i = destIndex;
            int index = 0;
            int size = arr.Length;
            while (index < size)
            {
                Write16(i, arr[index++]);
                i++;
                i++;
            }
        }


        public void RestoreFromBackup()
        {
            // Make sure rom is clear
            rom = new List<byte>();
            // Copy Over
            rom.AddRange(backupRom);
        }

        // For ROM validation
        private string GetChecksum(byte[] tempArr)
        {
            Int32 checksum = 0;
            foreach (var @byte in tempArr)
                checksum += @byte;
            return checksum.ToString("x");
        }
        // Compare header title
        public bool VerifyROM (byte[] arr, string headerString)
        {
            // Loop through string
            for (int i = 0; i < headerString.Length; i++)
            {
                if (headerString[i] != (char)arr[i])
                {
                    return false;
                }
            }

            return true;
        }


        // Save file
        public void SaveROM(string @string)
        {
            System.IO.File.WriteAllBytes(@string, rom.ToArray());
            MessageBox.Show("Saved!");
            WriteToBackup();

        }

        // Save As file
        public void SaveAsROM()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "ROM file (*.smc)|*.smc;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                fileName = dialog.FileName;

                WriteBackup();
                System.IO.File.WriteAllBytes(dialog.FileName, rom.ToArray());


                saved = true;

                sd.Write("File", "Path", fileName);
                sd.SaveRbs();

                MessageBox.Show("Saved!");

                //RestoreFromBackup();

                WriteToBackup();
            }
        }

        private void WriteBackup()
        {
        }

        public void SaveBackup()
        {
        }
        public bool IsROMChanged ()
        {
            if (rom.Count != backupRom.Length)
            {
                return true;
            }
            // Loop through every byte and check
            for (int i = 0; i < rom.Count; i++)
            {
                if (rom[i] != backupRom[i])
                {
                    return true;
                }
            }
            return false;
        }
        private void WriteToBackup ()
        {
            backupRom = new byte[rom.Count];
            for (int i = 0; i < backupRom.Length; i++)
            {
                backupRom[i] = rom[i];
            }
        }

        public string GetTitle()
        {
            var @return = (fileName.Length > maxFileNameLength) ? fileName.Substring(fileName.Length - maxFileNameLength) : fileName;

            return @return;
        }

        public string GetTitleFromHeader (byte[] arr)
        {
            var @return = "";
            foreach (var @byte in arr)
            {
                @return += (char)@byte;
            }
            return @return;
        }

        public void ExpandROM()
        {
            // Expand logically first
            rom[0xffd7] = 0xd;

            // Expand to 6 mb
            var expandBy = new byte[0x200000];
            rom.AddRange(expandBy);

            // - In the file, expand to 6mb and copy the data from 0x008000-0x00FFFF to 0x408000-0x40FFFF
            for (int i = 0x8000; i <= 0xffff; i++)
            {
                rom[0x400000 + i] = rom[i];
            }
            //for (int i = 0x260000; i <= 0x26ffff; i++)
            //{
            //    rom[0x400000 + i] = rom[i];
            //}


            // Deep copy to be sure
            var temp = new List<byte>();
            temp.AddRange(rom);
            // Copy to backup
            //backupRom = temp.ToArray();

        }
        public void AddToBackupList (byte[] arr)
        {
            if (backedupList.Count > 0)
            {
                var topmost = backedupList.Peek();
                if (topmost.SequenceEqual(arr))
                    return;
            }

            List<byte> temp = new List<byte>();
            temp.AddRange(arr);
            backedupList.Push(temp.ToArray());
            foreach(var a in backedupList)
            {
                var z = GetChecksum(a);

            }
        }
        public bool RestoreFromList()
        {
            if (backedupList.Count == 0)
                return false;
            rom = backedupList.Pop().ToList();
            return true;
        }
        public void LaunchEmu()
        {
            try
            {
                SaveBackup();
                System.Diagnostics.Process.Start(emuPath, romPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void SelectROMToLoad ()
        {
            
            

        }
        public void SelectEmuPath()
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Select emu exe";
            d.Filter = "EXE (*.exe)|*.exe";

            if (d.ShowDialog() == DialogResult.OK)
            {
                var temp = d.FileName;
                emuPath = d.FileName;

                var temp2 = temp.Substring(0, temp.LastIndexOf('\\') + 1);
                
                sd.Write("Connect", "EmuTest", emuPath);
                //sd.Write("Connect", "ROMTest", Global.romPath);
                sd.SaveRbs();

            }

        }
        public List<byte> Clone()
        {
            List<byte> @return = new List<byte>();
            @return.AddRange(rom);
            return @return;
        }
    }
}
