using System.ComponentModel;

namespace Axiom.Anamnese.Web.Models.Enum
{
    public enum PressureLevel
    {
        [Description("Alta")]
        HIGH,
        [Description("Baixa")]
        LOW,
        [Description("Normal")]
        NONE
    }

    public enum ServiceExpectations
    {
        [Description("Relaxamento")]
        Relaxation,
        [Description("Redução de medidas")]
        MeasuresReduction,
        [Description("Redução de dor")]
        PainReduction,
        [Description("Tratamento de doença")]
        DiseaseTreatment
    }

    public enum TouchPressure
    {
        [Description("Super Leve")]
        SuperLight,
        [Description("Leve")]
        Light,
        [Description("Média")]
        Medium,
        [Description("Forte")]
        Strong,
        [Description("Muito Forte")]
        VeryStrong,
        [Description("Não Sei")]
        DontKnow
    }
}
