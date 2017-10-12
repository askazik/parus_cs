using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;

namespace parus
{
    // Структура заголовка файла ионограммы.
    struct IonogramInfo2 {
        // GMT время получения ионограммы -----------------------------
        public int tm_sec;      //	seconds after the minute	0-60*
        public int tm_min;	    //	minutes after the hour	0-59
        public int tm_hour;	    //	hours since midnight	0-23
        public int tm_mday;	    //	day of the month	1-31
        public int tm_mon;	    //	months since January	0-11
        public int tm_year;	    //	years since 1900	
        public int tm_wday;	    //	days since Sunday	0-6
        public int tm_yday;	    //	days since January 1	0-365
        public int tm_isdst;	//	Daylight Saving Time flag
	    // ------------------------------------------------------------
        public uint height_min; // начальная высота, м (0 не означает, что зондирование от поверхности. Есть задержки!!!)
        public uint height_step; // шаг по высоте, м
        public uint count_height; // число высот
        public uint switch_frequency; // частота переключения антенн ионозонда 
        public uint freq_min; // начальная частота, кГц (первого модуля)
        public uint freq_max; // конечная частота, кГц (последнего модуля)   
        public uint count_freq; // число частот во всех модулях
        public uint count_modules; // количество модулей зондирования

        public string toString() {
            string tmp = "";
            //Console.WriteLine("Имя: {0}, возраст: {1}", Name, Age);

            return tmp;
        }
    } // Конец struct IonogramInfo2

    /* =====================================================================  */
    /* Родные структуры данных ИПГ-ИЗМИРАН */
    /* =====================================================================  */
    /* Каждая строка начинается с заголовка следующей структуры */
    struct FrequencyData {
        public ushort frequency; //!< Частота зондирования, [кГц].
        public ushort gain_control; // !< Значение ослабления входного аттенюатора дБ.
        public ushort pulse_time; //!< Время зондирования на одной частоте, [мс].
        public byte pulse_length; //!< Длительность зондирующего импульса, [мкc].
        public byte band; //!< Полоса сигнала, [кГц].
        public byte type; //!< Вид модуляции (0 - гладкий импульс, 1 - ФКМ).
        public byte threshold_o; //!< Порог амплитуды обыкновенной волны, ниже которого отклики не будут записываться в файл, [Дб/ед. АЦП].
        public byte threshold_x; //!< Порог амплитуды необыкновенной волны, ниже которого отклики не будут записываться в файл, [Дб/ед. АЦП].
        public byte count_o; //!< Число сигналов компоненты O.
        public byte count_x; //!< Число сигналов компоненты X.
    }

    /* Сначала следуют FrequencyData::count_o структур SignalResponse, описывающих обыкновенную волну. */
    /* Cразу же после перечисления всех SignalResponse  и SignalSample  для обыкновенных откликов следуют FrequencyData::count_x */
    /* структур SignalResponse, описывающих необыкновенные отклики с массивом структур SignalSample после каждой из них. Величины */
    /* FrequencyData::count_o и FrequencyData::count_x могут быть равны нулю, тогда соответствующие данные отсутствуют. */
    struct SignalResponse {
        public ulong height_begin; //!< начальная высота, [м]
        public ushort count_samples; //!< Число дискретов
    }

    class IonogramReader
    {
        // Поля
        private uint _ver; // номер версии формата ионограммы
        private IonogramInfo2 _header; // заголовок ионограммы
        private string _filename; // путь к файлу ионограммы
        private Bitmap _image = null; // рисунок ионограммы

        // Свойства
        public string FileName { get { return _filename; } }
        public uint Version { get { return _ver; } }
        public IonogramInfo2 Header { get { return _header; } }

        // Методы
        public IonogramReader(string fname)
        {
            this._filename = fname;

            try
            {
                // создаем объект BinaryReader
                using (BinaryReader reader = new BinaryReader(File.Open(fname, FileMode.Open)))
                {
                    _ver = reader.ReadUInt32();
                    switch (_ver)
                    {
                        case 0:
                            _header = readHeader2(reader);
                            _image = new Bitmap(
                                (int)_header.count_freq, 
                                (int)_header.count_height, 
                                System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                            fillImage(reader);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("Неизвестная версия формата файла ионограмм.");
                    }
                }
            }
            catch (Exception e)
            {
                string caption = "Ошибка при чтении файла " + this._filename + '.';
                ErrorMessage eb = new ErrorMessage(caption, e.Message);
            }
        }

        protected IonogramInfo2 readHeader2(BinaryReader reader)
        {
            IonogramInfo2 tmp;

            // GMT время получения ионограммы -----------------------------
            tmp.tm_sec = reader.ReadInt32();      //	seconds after the minute	0-60*
            tmp.tm_min = reader.ReadInt32();	    //	minutes after the hour	0-59
            tmp.tm_hour = reader.ReadInt32();	    //	hours since midnight	0-23
            tmp.tm_mday = reader.ReadInt32();	    //	day of the month	1-31
            tmp.tm_mon = reader.ReadInt32();	    //	months since January	0-11
            tmp.tm_year = reader.ReadInt32();	    //	years since 1900	
            tmp.tm_wday = reader.ReadInt32();	    //	days since Sunday	0-6
            tmp.tm_yday = reader.ReadInt32();	    //	days since January 1	0-365
            tmp.tm_isdst = reader.ReadInt32();	//	Daylight Saving Time flag
	        // ------------------------------------------------------------
            tmp.height_min = reader.ReadUInt32(); // начальная высота, м (0 не означает, что зондирование от поверхности. Есть задержки!!!)
            tmp.height_step = reader.ReadUInt32(); // шаг по высоте, м
            tmp.count_height = reader.ReadUInt32(); // число высот
            tmp.switch_frequency = reader.ReadUInt32(); // частота переключения антенн ионозонда 
            tmp.freq_min = reader.ReadUInt32(); // начальная частота, кГц (первого модуля)
            tmp.freq_max = reader.ReadUInt32(); // конечная частота, кГц (последнего модуля)   
            tmp.count_freq = reader.ReadUInt32(); // число частот во всех модулях
            tmp.count_modules = reader.ReadUInt32(); // количество модулей зондирования

            return tmp;
        }

        protected FrequencyData readFrequencyData(BinaryReader reader)
        {
            FrequencyData tmp = new FrequencyData();
        
            tmp.frequency = reader.ReadUInt16(); //!< Частота зондирования, [кГц].
            tmp.gain_control = reader.ReadUInt16(); // !< Значение ослабления входного аттенюатора дБ.
            tmp.pulse_time = reader.ReadUInt16(); //!< Время зондирования на одной частоте, [мс].
            tmp.pulse_length = reader.ReadByte(); //!< Длительность зондирующего импульса, [мкc].
            tmp.band = reader.ReadByte(); //!< Полоса сигнала, [кГц].
            tmp.type = reader.ReadByte(); //!< Вид модуляции (0 - гладкий импульс, 1 - ФКМ).
            tmp.threshold_o = reader.ReadByte(); //!< Порог амплитуды обыкновенной волны, ниже которого отклики не будут записываться в файл, [Дб/ед. АЦП].
            tmp.threshold_x = reader.ReadByte(); //!< Порог амплитуды необыкновенной волны, ниже которого отклики не будут записываться в файл, [Дб/ед. АЦП].
            tmp.count_o = reader.ReadByte(); //!< Число сигналов компоненты O.
            tmp.count_x = reader.ReadByte(); //!< Число сигналов компоненты X.
            
            return tmp;
        }

        protected SignalResponse readSignalResponse(BinaryReader reader){
            SignalResponse tmp = new SignalResponse();

            tmp.height_begin = reader.ReadUInt32(); //!< начальная высота, [м]
            tmp.count_samples = reader.ReadUInt16(); //!< Число дискретов

            return tmp;
        }

        protected void fillImage(BinaryReader reader)
        {
            FrequencyData curFrq;
            SignalResponse curSignal;
            int i;
            byte[] samples;

            // пока не достигнут конец файла считываем каждое значение из файла
            bool file_eof;
            do
            {
                curFrq = readFrequencyData(reader);
                for (i = 0; i < curFrq.count_o; i++)
                {
                    curSignal = readSignalResponse(reader);
                    samples = reader.ReadBytes(curSignal.count_samples);
                }
                file_eof = reader.BaseStream.Position >= reader.BaseStream.Length;
            }
            while (!file_eof); // если возникает ошибка - файл битый
        }
    }
}
