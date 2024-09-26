using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskEvaluating_WinForms_
{
    internal class Rules
    {
        public static string HQ_rule(float HQ)
        {
            if (HQ <= 0.1f) return "Минимальный";
            else if (HQ > 0.1f && HQ <= 1.0f) return "Допустимый";
            else if (HQ > 1.0f && HQ <= 3.0f) return "Настораживающий";
            else return "Высокий";
        }

        public static string HI_rule(float HI)
        {
            if (HI <= 1.0f) return "Минимальный (целевой)";
            else if (HI > 1.0f && HI <= 3.0f) return "Допустимый";
            else if (HI > 3.0f && HI <= 6.0f) return "Настораживающий";
            else return "Высокий";
        }

        public static float RiskProbitTable(float probit)
        {
            float[,] RiskToPercent = new float[45, 2];
            float risk = 0;

            RiskToPercent[0, 0] = 3; RiskToPercent[0, 1] = 0.999f;
            RiskToPercent[1, 0] = 2.5f; RiskToPercent[1, 1] = 0.994f;
            RiskToPercent[2, 0] = 2; RiskToPercent[2, 1] = 0.977f;
            RiskToPercent[3, 0] = 1.9f; RiskToPercent[3, 1] = 0.971f;
            RiskToPercent[4, 0] = 1.8f; RiskToPercent[4, 1] = 0.964f;
            RiskToPercent[5, 0] = 1.7f; RiskToPercent[5, 1] = 0.955f;
            RiskToPercent[6, 0] = 1.6f; RiskToPercent[6, 1] = 0.945f;
            RiskToPercent[7, 0] = 1.5f; RiskToPercent[7, 1] = 0.933f;
            RiskToPercent[8, 0] = 1.4f; RiskToPercent[8, 1] = 0.919f;
            RiskToPercent[9, 0] = 1.3f; RiskToPercent[9, 1] = 0.903f;
            RiskToPercent[10, 0] = 1.2f; RiskToPercent[10, 1] = 0.885f;
            RiskToPercent[11, 0] = 1.1f; RiskToPercent[11, 1] = 0.864f;
            RiskToPercent[12, 0] = 1.0f; RiskToPercent[12, 1] = 0.841f;
            RiskToPercent[13, 0] = 0.9f; RiskToPercent[13, 1] = 0.816f;
            RiskToPercent[14, 0] = 0.8f; RiskToPercent[14, 1] = 0.788f;
            RiskToPercent[15, 0] = 0.7f; RiskToPercent[15, 1] = 0.758f;
            RiskToPercent[16, 0] = 0.6f; RiskToPercent[16, 1] = 0.726f;
            RiskToPercent[17, 0] = 0.5f; RiskToPercent[17, 1] = 0.692f;
            RiskToPercent[18, 0] = 0.4f; RiskToPercent[18, 1] = 0.655f;
            RiskToPercent[19, 0] = 0.3f; RiskToPercent[19, 1] = 0.618f;
            RiskToPercent[20, 0] = 0.2f; RiskToPercent[20, 1] = 0.579f;
            RiskToPercent[21, 0] = 0.1f; RiskToPercent[21, 1] = 0.540f;
            RiskToPercent[22, 0] = 0; RiskToPercent[22, 1] = 0.5f;
            RiskToPercent[23, 0] = -0.1f; RiskToPercent[23, 1] = 0.460f;
            RiskToPercent[24, 0] = -0.2f; RiskToPercent[24, 1] = 0.421f;
            RiskToPercent[25, 0] = -0.3f; RiskToPercent[25, 1] = 0.382f;
            RiskToPercent[26, 0] = -0.4f; RiskToPercent[26, 1] = 0.345f;
            RiskToPercent[27, 0] = -0.5f; RiskToPercent[27, 1] = 0.309f;
            RiskToPercent[28, 0] = -0.6f; RiskToPercent[28, 1] = 0.274f;
            RiskToPercent[29, 0] = -0.7f; RiskToPercent[29, 1] = 0.242f;
            RiskToPercent[30, 0] = -0.8f; RiskToPercent[30, 1] = 0.212f;
            RiskToPercent[31, 0] = -0.9f; RiskToPercent[31, 1] = 0.184f;
            RiskToPercent[32, 0] = -1; RiskToPercent[32, 1] = 0.157f;
            RiskToPercent[33, 0] = -1.1f; RiskToPercent[33, 1] = 0.136f;
            RiskToPercent[34, 0] = -1.2f; RiskToPercent[34, 1] = 0.115f;
            RiskToPercent[35, 0] = -1.3f; RiskToPercent[35, 1] = 0.097f;
            RiskToPercent[36, 0] = -1.4f; RiskToPercent[36, 1] = 0.081f;
            RiskToPercent[37, 0] = -1.5f; RiskToPercent[37, 1] = 0.067f;
            RiskToPercent[38, 0] = -1.6f; RiskToPercent[38, 1] = 0.055f;
            RiskToPercent[39, 0] = -1.7f; RiskToPercent[39, 1] = 0.045f;
            RiskToPercent[40, 0] = -1.8f; RiskToPercent[40, 1] = 0.036f;
            RiskToPercent[41, 0] = -1.9f; RiskToPercent[41, 1] = 0.029f;
            RiskToPercent[42, 0] = -2; RiskToPercent[42, 1] = 0.023f;
            RiskToPercent[43, 0] = -2.5f; RiskToPercent[43, 1] = 0.006f;
            RiskToPercent[44, 0] = -3; RiskToPercent[44, 1] = 0.001f;

            bool wasFounded = false;
            for (int i = 0; i <= 44; i++)
            {
                if (probit == RiskToPercent[i, 0])
                {
                    risk = RiskToPercent[i, 1];
                    wasFounded = true;
                }
                else if (probit < -3)
                {
                    risk = 0.001f;
                    wasFounded = true;
                }
                else if (probit > 3)
                {
                    risk = 0.999f;
                    wasFounded = true;
                }
                else if (probit == -2.1f || probit == -2.2f || probit == -2.3f || probit == -2.4f)
                {
                    risk = 0.006f;
                    wasFounded = true;
                }
                else if (probit == 2.1f || probit == 2.2f || probit == 2.3f || probit == 2.4f)
                {
                    risk = 0.994f;
                    wasFounded = true;
                }
                else if (probit == -2.6f || probit == -2.7f || probit == -2.8f || probit == -2.9f)
                {
                    risk = 0.001f;
                    wasFounded = true;
                }
                else if (probit == 2.6f || probit == 2.7f || probit == 2.8f || probit == 2.9f)
                {
                    risk = 0.999f;
                    wasFounded = true;
                }
            }
            if (wasFounded == false) risk = 101099;
            return risk;
        }

        public static string Risk_rule(float risk)
        {
            if (risk <= 0.05f) return "Приемлемый (минимальный)";
            else if (risk > 0.05f && risk <= 0.16f) return "Удовлетворительный";
            else if (risk > 0.16f && risk <= 0.5f) return "Неудовлетворительный";
            else if (risk > 0.5f && risk <= 0.9f) return "Опасный";
            else return "Чрезвычайно опасный";
        }
    }
}
