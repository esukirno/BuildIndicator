﻿namespace IsBambooBuildBrokenReader
{
    public class BuildNotification
    {
        public BuildNotification(ResultCheckpoint checkpoint, string name, string description, BuildStatus status)
        {
            Checkpoint = checkpoint;
            Name = name;
            Description = description;
            Status = status;
        }

        public ResultCheckpoint Checkpoint { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BuildStatus Status { get; set; }

        public override string ToString()
        {
            return string.Format("Checkpoint: {0}, Name: {1}, Status: {2}", Checkpoint, Name, Status);
        }
    }
}