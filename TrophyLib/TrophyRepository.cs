using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLib
{
    public class TrophyRepository
    {
        private int _nextId = 1;
        private readonly List<Trophy> _trophies = new();

        public TrophyRepository() { }

        public Trophy? GetById(int id)
        {
            return _trophies.Find(movie => movie.Id == id);
        }

        public Trophy Add(Trophy trophy)
        {
            trophy.Validate();
            trophy.Id = _nextId++;
            _trophies.Add(trophy);
            return trophy;
        }

        public IEnumerable<Trophy> Get(int? yearAfter = null, string? compIncludes = null, string? orderBy = null)
        {
            IEnumerable<Trophy> result = new List<Trophy>(_trophies);
            // Filtering
            if (yearAfter != null)
            {
                result = result.Where(t => t.Year > yearAfter);
            }
            if (compIncludes != null)
            {
                result = result.Where(m => m.Competition.Contains(compIncludes));
            }

            // Ordering aka. sorting
            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "competition": // fall through to next case
                    case "comp_asc":
                        result = result.OrderBy(t => t.Competition);
                        break;
                    case "comp_desc":
                        result = result.OrderByDescending(t => t.Competition);
                        break;
                    case "year":
                    case "year_asc":
                        result = result.OrderBy(t => t.Year);
                        break;
                    case "year_desc":
                        result = result.OrderByDescending(t => t.Year);
                        break;
                    default:
                        break; // do nothing
                        //throw new ArgumentException("Unknown sort order: " + orderBy);
                }
            }
            return result;
        }

    }
}
