using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter 
{
    [Serializable]
    public class Tweets 
    {
        private List<Tweet> _tweets;

        public ReadOnlyCollection<Tweet> AlleTweets()
        {
            return new ReadOnlyCollection<Tweet>(_tweets);
        }

        public void AddTweet(Tweet tweet)
        {
            if (_tweets == null)
                _tweets = new List<Tweet>();
            _tweets.Add(tweet);
        }
    }
}
