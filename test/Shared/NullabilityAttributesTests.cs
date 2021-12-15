namespace System.Diagnostics.CodeAnalysis;

class Test {
    [AllowNull]
    public string AllowNull {
        get => allowNull;
        set => allowNull = value ?? "42";
    }
    private string allowNull = "42";

    [DisallowNull]
    public string? DisallowNull {
        get => disallowNull;
        set => disallowNull = value ?? throw new ArgumentNullException(nameof(DisallowNull), "Cannot set to null");
    }
    string? disallowNull;

    public string MemberNotNullAttribute { get; set; }
    [MemberNotNull(nameof(MemberNotNullAttribute))]
    void SetMemberNotNull() {
        MemberNotNullAttribute = "42";
    }

    public Test() {
        SetMemberNotNull();
    }

    public static void Main() {
        var test = new Test();
        // AllowNull
        test.AllowNull = null;
    }
}