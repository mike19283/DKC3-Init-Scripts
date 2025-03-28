using DKC3_Init_scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKC3_Init_scripts
{
    public partial class Form1 : Form
    {
        ROM rom;
        StoredData sd = new StoredData("eyelykedkc3");
        static byte[] paramCountLut = new byte[] { 0, 0, 3, 2, 2, 11, 0, 2, 5, 8, 2, 2, 2, 2, 2, 2, 2 };
        int basPoint = 0;
        int functionLUT = 0xbb8084;
        int entityList = 0xff0040;
        int keyTimer = 0;
        Dictionary<int, string> commandNames = new Dictionary<int, string>()
        {
            [0xef] = "Return (ef)",
            [0xf0] = "Return with second highest priority (f0)",
            [0xf1] = "ID hard change (f1)",
            [0xf2] = "??? (f2)",
            [0xf3] = "??? (f3)",
            [0xf4] = "??? (f4)",
            [0xf5] = "??? (f5)",
            [0xf6] = "Position relative to parent (f6)",
            [0xf7] = "??? (f7)",
            [0xf8] = "Call variable subroutine (f8)",
            [0xf9] = "Call subroutine (f9)",
            [0xfa] = "Default animation (fa)",
            [0xfb] = "??? (fb)",
            [0xfc] = "Palette Index (fc)",
            [0xfd] = "??? (fd)",
            [0xfe] = "Facing/Priority (fe)",
            [0xff] = "ID Init (ff)",

        };
        List<KeyValueScript> script = new List<KeyValueScript>();
        List<KeyValueScript> allScripts = new List<KeyValueScript>();


        public Form1()
        {
            InitializeComponent();
            rom = new ROM(sd);
            //loadToolStripMenuItem_Click(0, new EventArgs());
            AddHotkeyToAll(this);
            button_apply.Enabled = false;
            label_sprite.Text = "";
        }
        private void PointerFocus()
        {
            numericUpDown_pointer.Focus();
            numericUpDown_pointer.Select(4, 0);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rom.Load();
            if (rom.loadROMSuccess)
            {
                numericUpDown_pointer.Focus();
                //MessageBox.Show("Loaded");
                this.Text = rom.fileName;
            }
            numericUpDown_pointer.Focus();
            PointerFocus();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            if (!rom.loadROMSuccess)
            {
                MessageBox.Show("ROM not loaded");
                return;
            }
            if (numericUpDown_value.Focused == true)
            {
                button_apply_Click(0, new EventArgs());
                return;
            }
            if (numericUpDown_key.Focused)
            {
                return;
            }

            if (numericUpDown_pointer.Value == 0)
            {
                return;
            }


            int pointer = 0, 
                num = (int)numericUpDown_pointer.Value;
            numericUpDown_pointer.Value = 0;
            if (radioButton_pointer.Checked)
            {
                //pointer = rom.Read16(0xff218c + num);
                pointer = rom.Read16(entityList + num);
                basPoint = num;
                if (rom.entityPointers.ContainsKey(num))
                {
                    label_sprite.Text = rom.entityPointers[num];
                }
                else
                {
                    label_sprite.Text = "Unknown";
                    return;
                }
            }
            else if (radioButton_absPointer.Checked)
            {
                pointer = num;
                basPoint = 0;
            }
            
            try
            {
                allScripts.AddRange(ReadScript(pointer));
            }
            catch { MessageBox.Show("Bad pointer"); }
            RefreshListbox();
            PointerFocus();
        }
        private void RefreshListbox()
        {
            listBox_scriptEdit.Items.Clear();
            listBox_scriptEdit.Items.AddRange(allScripts.ToArray());
        }
        private List<KeyValueScript> ReadScript(int address)
        {
            int absPointer = address;
            address += 0xff0000;
            List<KeyValueScript> rtn = new List<KeyValueScript>();
            Stack<int> calls = new Stack<int>();
            rtn.Add(new KeyValueScript(0, address.ToString("X6") + " - " + basPoint.ToString("X4")));

            string spaces = "";
            while (true)
            {
                spaces = new string(' ', calls.Count * 4);
                int ogAddress = address;
                // Read command value
                Int32 command = rom.Read16(address++);
                command &= 0xff;


                // What category is command?
                if (command < 0xef)
                {
                    // Set array value
                    Int32 value = rom.Read16(ref address);
                    KeyValueScript keyvalue = new KeyValueScript(ogAddress, spaces + string.Format("[{0:x2}] = {1:x4}", command, value));
                    keyvalue.key = command;
                    keyvalue.values.Add(value);
                    keyvalue.pointer = absPointer;
                    rtn.Add(keyvalue);
                }
                else
                {
                    spaces = new string(' ', calls.Count * 4);
                    int newAddr = 0;
                    // Hard-coded call
                    int @params = paramCountLut[command - 0xef];
                    string txt = spaces + string.Format("{0:x2} -> ", GetCommand(command));
                    // Command specific actions
                    switch (command)
                    {
                        case 0xef:
                            // Return
                            if (calls.Count <= 0)
                            {
                                rtn.Add(new KeyValueScript(0, "=========="));
                                return rtn;
                            }

                            address = calls.Pop();
                            break;
                        case 0xf0:
                            // Return
                            if (calls.Count <= 0)
                            {
                                rtn.Add(new KeyValueScript(0, "=========="));
                                return rtn;
                            }

                            address = calls.Pop();
                            break;
                        case 0xf1:
                            txt += string.Format("{0:x2} ", rom.Read8(ref address));
                            txt += string.Format("{0:x4} ", rom.Read16(ref address));
                            break;
                        case 0xf2:
                            txt += string.Format("{0:x4} ", rom.Read16(ref address));
                            break;
                        case 0xf3:
                            txt += string.Format("{0:x2} ", rom.Read8(ref address));
                            txt += string.Format("{0:x2} ", rom.Read8(ref address));
                            break;
                        case 0xf4:
                            newAddr = 0xff0000 + rom.Read16(address);
                            txt += string.Format("{0:x4} ", rom.Read16(ref address));


                            txt += string.Format("{0:x2} ", rom.Read8(ref address));
                            txt += string.Format("{0:x2} ", rom.Read8(ref address));
                            txt += string.Format("{0:x2} ", rom.Read8(ref address));
                            txt += string.Format("{0:x2} ", rom.Read8(ref address));
                            txt += string.Format("{0:x2} ", rom.Read8(ref address));
                            txt += string.Format("{0:x2} ", rom.Read8(ref address));
                            txt += string.Format("{0:x2} ", rom.Read8(ref address));
                            txt += string.Format("{0:x2} ", rom.Read8(ref address));
                            txt += string.Format("{0:x2}: ", rom.Read8(ref address));

                            // Call
                            calls.Push(address);
                            address = newAddr;
                            spaces = new string(' ', calls.Count * 2);
                            break;
                        case 0xf5:
                            break;
                        case 0xf6:
                            txt += string.Format("{0:x2} ", rom.Read8(ref address));
                            txt += string.Format("{0:x2} ", rom.Read8(ref address));
                            break;
                        case 0xf7:
                            txt += string.Format("{0:x4} ", rom.Read16(ref address));
                            txt += string.Format("{0:x4} ", rom.Read16(ref address));
                            txt += string.Format("{0:x2} ", rom.Read8(ref address));
                            break;
                        case 0xf8:
                            txt += string.Format("{0:x4} ", rom.Read16(ref address));
                            txt += string.Format("{0:x4} ", rom.Read16(ref address));
                            newAddr = 0xff0000 + rom.Read16(address);

                            txt += string.Format("{0:x4} ", rom.Read16(ref address));
                            txt += string.Format("{0:x4}: ", rom.Read16(ref address));
                            // Call
                            calls.Push(address);
                            address = newAddr;

                            spaces = new string(' ', calls.Count * 2);

                            break;
                        case 0xf9:
                            newAddr = 0xff0000 + rom.Read16(address);
                            txt += string.Format("{0:x4}: ", rom.Read16(ref address));
                            // Call
                            calls.Push(address);
                            address = newAddr;
                            spaces = new string(' ', calls.Count * 2);
                            break;
                        case 0xfa:
                            txt += string.Format("{0:x4} ", rom.Read16(ref address));
                            break;
                        case 0xfb:
                            txt += string.Format("{0:x4} ", rom.Read16(ref address));
                            break;
                        case 0xfc:
                            txt += string.Format("{0:x4} ", rom.Read16(ref address));
                            break;
                        case 0xfd:
                            txt += string.Format("{0:x4} ", rom.Read16(ref address));
                            break;
                        case 0xfe:
                            txt += string.Format("{0:x4} ", rom.Read16(ref address));
                            break;
                        case 0xff:
                            ushort id = rom.Read16(ref address);
                            txt += string.Format("{0:x4} ", id);
                            txt += string.Format(" {0:X6}", rom.Read24(functionLUT + id));
                            break;

                        default:
                            break;
                    }
                    rtn.Add(new KeyValueScript(ogAddress, txt));
                }
            }


            return rtn;
        }
        private string GetCommand(int cmd)
        {
            if (commandNames.ContainsKey(cmd))
            {
                return commandNames[cmd];
            }
            else
            {
                return cmd.ToString("X2");
            }
        }

        private void listBox_scriptEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_apply.Enabled = false;
            if (listBox_scriptEdit.SelectedIndex == -1)
            {
                numericUpDown_key.Value = 0;
                numericUpDown_value.Value = 0;
                return;
            }
            KeyValueScript script = (KeyValueScript)listBox_scriptEdit.SelectedItem;
            label_scriptAddress.Text = script.addr.ToString("X");
            if (script.key != -1)
            {
                button_apply.Enabled = true;
                numericUpDown_key.Value = script.key;
                numericUpDown_value.Value = script.values[0];
                numericUpDown_value.Focus();
                numericUpDown_value.DecimalPlaces = 4;
                numericUpDown_value.Select(4, 0);
            }
            else
            {
                numericUpDown_key.Value = 0;
                numericUpDown_value.Value = 0;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rom.SaveROM(rom.fileName);
        }
        private void AddHotkeyToAll(Control ctrl)
        {
            ctrl.KeyDown += new KeyEventHandler(Keydown);
            foreach (Control child in ctrl.Controls)
            {
                AddHotkeyToAll(child);
            }
        }
        private void Keydown (object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control && rom != null && rom.loadROMSuccess && keyTimer == 0)
            {
                rom.SaveROM(rom.fileName);
                timer1.Enabled = true;
                keyTimer = 100;
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (keyTimer != 0)
            {
                keyTimer--;
            }
        }

        private void button_empty_Click(object sender, EventArgs e)
        {
            allScripts = new List<KeyValueScript>();
            RefreshListbox();
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            if (listBox_scriptEdit.SelectedIndex == -1)
                return;
            KeyValueScript script = (KeyValueScript)listBox_scriptEdit.SelectedItem;
            int addr = script.addr;
            rom.Write8(addr + 0, (int)numericUpDown_key.Value);
            rom.Write16(addr + 1, (int)numericUpDown_value.Value);
            basPoint = 0;

            allScripts = new List<KeyValueScript>();
            allScripts.AddRange(ReadScript(script.pointer));
            RefreshListbox();
            listBox_scriptEdit.SelectedIndex = 0;

        }

        private void button_spriteSelect_Click(object sender, EventArgs e)
        {
            SpriteSelect ss = new SpriteSelect(rom);

            if (ss.ShowDialog() == DialogResult.OK)
            {
                var sel = ss.selection;
                numericUpDown_pointer.Value = sel.key;
            }
        }
    }
}
