using System;
namespace MicrosoftNews.Services.DatabaseInteraction
{
    public interface IDatabaseInteractionService
    {
        void WriteToDB();
        void ReadFromDB();
    }
}
