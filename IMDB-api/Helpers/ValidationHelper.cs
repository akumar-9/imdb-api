using IMDB_api.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Helpers
{
    public static class ValidationHelper
    {
        public static void ValidateActor(ActorRequest actorRequest)
        {         
            if (string.IsNullOrEmpty(actorRequest.Name))
                throw new Exception("Actor's name cannot be null");
                    if (string.IsNullOrEmpty(actorRequest.Bio))
            throw new Exception("Actor's bio cannot be null");
                    if (string.IsNullOrEmpty(actorRequest.Sex))
            throw new Exception("Actor's sex cannot be null");
                    if (actorRequest.DOB.CompareTo(DateTime.Today) > 0)
            throw new Exception("Actor should atleast be a year old");
        }
        public static void ValidateProducer(ProducerRequest producerRequest)
        {         
            if (string.IsNullOrEmpty(producerRequest.Name))
                throw new Exception("Producer's name cannot be null");
                    if (string.IsNullOrEmpty(producerRequest.Bio))
            throw new Exception("Producer's bio cannot be null");
                    if (string.IsNullOrEmpty(producerRequest.Sex))
            throw new Exception("Producer's sex cannot be null");
                    if (producerRequest.DOB.CompareTo(DateTime.Today) > 0)
            throw new Exception("Producer should atleast be a year old");
        }
        public static void ValidateMovie(MovieRequest movieRequest)
		{
			if(string.IsNullOrEmpty(movieRequest.Name))
				throw new Exception("Movie's name cannot be null");
			if(string.IsNullOrEmpty(movieRequest.Plot))
				throw new Exception("Movie's plot cannot be null");
			if(string.IsNullOrEmpty(movieRequest.Poster))
				throw new Exception("Movie's poster url cannot be null");
			
            if (movieRequest.ActorIds.Count < 0)
                throw new Exception("The movie must have atleast one actor id");
            if (movieRequest.GenreIds.Count < 0)
                throw new Exception("The movie must have atleast one genre id");
		}

        public static void ValidateGenre(GenreRequest genreRequest)
		{
			if(string.IsNullOrEmpty(genreRequest.Name))
				throw new Exception("Genre's name cannot be null");
		}
    }
}
