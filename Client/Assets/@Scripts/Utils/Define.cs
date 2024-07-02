// enum 값을 정리해서 관리하는 클래스
// 프로젝트의 규모가 커진다면 분리가 필요한 부분
public static class Define
{
    public enum EScene
    {
        Unknown,
        TitleScene,
        GameScene,
    }

    public enum EUIEvent
    {
        Click,
        PointerDown,
        PointerUp,
        Drag,
    }

    public enum ESound
    {
        Bgm,
        Effect,
        Max,
    }
}
