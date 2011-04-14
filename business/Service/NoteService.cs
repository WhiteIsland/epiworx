using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Service
{
    [Serializable]
    public class NoteService
    {
        public static Note NoteAdd(ISource source, string body)
        {
            var result = NoteService.NoteAdd(source.SourceType, source.SourceId, body);

            return result;
        }

        public static Note NoteAdd(SourceType sourceType, int sourceId, string body)
        {
            var result = NoteService.NoteNew(sourceType, sourceId);

            result.Body = body;

            result = NoteService.NoteSave(result);

            return result;
        }

        public static Note NoteFetch(int noteId)
        {
            return Note.FetchNote(
                new NoteCriteria
                    {
                        NoteId = noteId
                    });
        }

        public static NoteInfoList NoteFetchInfoList()
        {
            return NoteService.NoteFetchInfoList(
                new NoteCriteria());
        }

        public static NoteInfoList NoteFetchInfoList(ISource source)
        {
            return NoteService.NoteFetchInfoList(
                new NoteCriteria
                {
                    SourceType = source.SourceType,
                    SourceId = new[] { source.SourceId }
                });
        }

        public static NoteInfoList NoteFetchInfoList(SourceType sourceType, int sourceId)
        {
            return NoteService.NoteFetchInfoList(
                new NoteCriteria
                    {
                        SourceType = sourceType,
                        SourceId = new[] { sourceId }
                    });
        }

        public static NoteInfoList NoteFetchInfoList(SourceType sourceType, int[] sourceId)
        {
            return NoteService.NoteFetchInfoList(
                new NoteCriteria
                {
                    SourceType = sourceType,
                    SourceId = sourceId
                });
        }

        public static NoteInfoList NoteFetchInfoList(NoteCriteria criteria)
        {
            return NoteInfoList.FetchNoteInfoList(criteria);
        }

        public static Note NoteSave(Note note)
        {
            if (!note.IsValid)
            {
                return note;
            }

            Note result;

            if (note.IsNew)
            {
                result = NoteService.NoteInsert(note);
            }
            else
            {
                result = NoteService.NoteUpdate(note);
            }

            return result;
        }

        public static Note NoteInsert(Note note)
        {
            note = note.Save();

            FeedService.FeedAdd("Created", note);

            return note;
        }

        public static Note NoteUpdate(Note note)
        {
            note = note.Save();

            FeedService.FeedAdd("Updated", note);

            return note;
        }

        public static Note NoteNew(SourceType sourceType, int sourceId)
        {
            var result = Note.NewNote(
               new NoteCriteria
               {
                   SourceType = sourceType,
                   SourceId = new[] { sourceId }
               });

            return result;
        }

        public static bool NoteDelete(Note note)
        {
            Note.DeleteNote(
                new NoteCriteria
                    {
                        NoteId = note.NoteId
                    });

            FeedService.FeedAdd("Deleted", note);

            return true;
        }

        public static bool NoteDelete(int noteId)
        {
            return NoteService.NoteDelete(
                NoteService.NoteFetch(noteId));
        }
    }
}