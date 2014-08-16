using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 *卡牌示例
 *卡包:DL2
 *日文名:ワイト
 *中文名:白骨
 *星级:1
 *罕贵度:平卡N
 *卡种:普通怪兽
 * 属性:暗
 * 种族:不死
 * 攻:300
 * 防:200
 */
namespace duel
{
    public class Card
    {
        public string showInfo { get; set; }

        public string status { get; set; }

        public string cardPackage { get; set; }
        public string japanName { get; set; }
        public string ChineseName { get; set; }
        public string StarNumber { get; set; }
        public string cardGrade { get; set; }
        public string cardSpecies { get; set; }
        public string attribute { get; set; }
        public string stirpt { get; set; }
        public string attack { get; set; }
        public string defend { get; set; }


        public string makeShowInfo()
        {
            showInfo = "";
            if (status != null)
            {
                showInfo = "状态：" + status + "\r\n";
            }

            showInfo += "怪兽名：" + ChineseName + "\r\n";
            showInfo += "攻击力：" + attack + "\r\n";
            showInfo += "防守力：" + defend + "\r\n";

            return showInfo;
        }

    }
}
