using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace initialzr.ui.Models {

    public class Initializer : System.Data.Entity.CreateDatabaseIfNotExists<InitialzrContext> {

        protected override void Seed(InitialzrContext context) {
            populateFaculty(context);
            populateDepartment(context);
            populateProfile(context);
            populateMessage(context);
            populatePost(context);
            populateChat(context);
        }

        private static void populateFaculty(InitialzrContext context) {
            var faculties = new List<Faculty> {
                new Faculty{
                    Title="Science and Technology",
                    Description ="SST"
                },
                new Faculty{
                    Title="Engineering and Environmental Studies",
                    Description ="SST"
                },
                new Faculty{
                    Title="Business",
                    Description ="SST"
                }
            };
            faculties.ForEach(ur => context.Faculties.Add(ur));
            context.SaveChanges();
        }

        private static void populateDepartment(InitialzrContext context) {
            var departments = new List<Department> {
                new Department{
                    Title="Computer Science",
                    Description="CS"
                },
                new Department{
                    Title="Mathematics and Statistics",
                    Description="M&S"
                },
                new Department{
                    Title="Science Laboratory Technology",
                    Description="SLT"
                },
                new Department{
                    Title="Building Technology",
                    Description="Building"
                },
                new Department{
                    Title="Civil Engineering",
                    Description="Civil"
                },
                new Department{
                    Title="Office Technology and Management",
                    Description="OTM"
                },
                new Department{
                    Title="Business Administration",
                    Description="BA"
                },
                new Department{
                    Title="Banking and Finance",
                    Description="B&F"
                }
            };

            int counter = 0;
            foreach (var fac in context.Faculties) {
                while (counter < departments.Count) {
                    fac.Departments.Add(departments[counter]);
                    counter++;
                    if (counter % 3 == 0) { break; }
                }
            }
            context.SaveChanges();
        }

        private static void populateProfile(InitialzrContext context) {
            var profiles = new List<Profile>{
                new Profile{
                    FirstName="Wilfred",    LastName="Adigwe",    About="Easy going Lecturer",  Sex="Male",
                    Email="adigwe@polychat.com",  RoleId=2,  Password="lecturer"
                },
                new Profile{
                    FirstName="Christabel",    LastName="Ika",    About="Fun loving and high spirited girl",  Sex="female",
                    Email="ika@polychat.com",  RoleId=1,  Password="student"
                },
                new Profile{
                    FirstName="John",    LastName="Ufouma",    About="Mention Code, That is how they spell my name",  Sex="Male",
                    Email="ufouma@polychat.com",  RoleId=2,  Password="student"
                },
                new Profile{
                    FirstName="Ese",    LastName="Iteveh",    About="Easy going Lecturer",  Sex="Male",
                    Email="iteveh@polychat.com",  RoleId=2,  Password="lecturer"
                },
                new Profile{
                    FirstName="Harriet",    LastName="Okoro",    About="Fun loving and high spirited girl",  Sex="female",
                    Email="okoro@polychat.com",  RoleId=2,  Password="student"
                },
                new Profile{
                    FirstName="John",    LastName="Edafe",    About="Mention Code, That is how they spell my name",  Sex="Male",
                    Email="edafe@polychat.com",  RoleId=2,  Password="student"
                },
                new Profile{
                    FirstName="Winifred",    LastName="Adigi",    About="Easy going Lecturer",  Sex="Male",
                    Email="adigi@polychat.com",  RoleId=2,  Password="lecturer"
                },
                new Profile{
                    FirstName="Rita",    LastName="Okwuguni",    About="Fun loving and high spirited girl",  Sex="female",
                    Email="okuguni@polychat.com",  RoleId=2,  Password="student"
                },
                new Profile{
                    FirstName="Christopher",    LastName="Udeme",    About="Mention Code, That is how they spell my name",  Sex="Male",
                    Email="udeme@polychat.com",  RoleId=2,  Password="student"
                },
                new Profile{
                    FirstName="Alonzo",    LastName="Aristos",    About="Easy going Lecturer",  Sex="Male",
                    Email="aristos@polychat.com",  RoleId=2,  Password="lecturer"
                },
                new Profile{
                    FirstName="Charity",    LastName="Uyimeh",    About="Fun loving and high spirited girl",  Sex="female",
                    Email="uyimeh@polychat.com",  RoleId=2,  Password="student"
                },
                new Profile{
                    FirstName="James",    LastName="Pela",    About="Mention Code, That is how they spell my name",  Sex="Male",
                    Email="pela@polychat.com",  RoleId=2,  Password="student"
                },
                new Profile{
                    FirstName="Sunday",    LastName="Ifeanyi",    About="Easy going Lecturer",  Sex="Male",
                    Email="ifeanyi@polychat.com",  RoleId=2,  Password="lecturer"
                },
                new Profile{
                    FirstName="Jennifer",    LastName="Ekobe",    About="Fun loving and high spirited girl",  Sex="female",
                    Email="ekobe@polychat.com",  RoleId=2,  Password="student"
                },
                new Profile{
                    FirstName="Matthew",    LastName="Korrect",    About="Mention Code, That is how they spell my name",  Sex="Male",
                    Email="korrect@polychat.com",  RoleId=2,  Password="student"
                },
                new Profile{
                    FirstName="Jessica",    LastName="Amiaya",    About="Easy going Lecturer",  Sex="Female",
                    Email="amiaya@polychat.com",  RoleId=2,  Password="lecturer"
                },
                new Profile{
                    FirstName="Sadiya",    LastName="Olaide",    About="Fun loving and high spirited girl",  Sex="female",
                    Email="olaide@polychat.com",  RoleId=2,  Password="student"
                },
                new Profile{
                    FirstName="Mohammed",    LastName="Abubakar",    About="Mention Code, That is how they spell my name",  Sex="Male",
                    Email="abubakar@polychat.com",  RoleId=2,  Password="student"
                },
                new Profile{
                    FirstName="Tejiri",    LastName="Oke",    About="Easy going Lecturer",  Sex="Male",
                    Email="oke@polychat.com",  RoleId=2,  Password="lecturer"
                },
                new Profile{
                    FirstName="Sandra",    LastName="Ibeh",    About="Fun loving and high spirited girl",  Sex="female",
                    Email="ibeh@polychat.com",  RoleId=2,  Password="student"
                },
                new Profile{
                    FirstName="Femi",    LastName="Aganmuyi",    About="Mention Code, That is how they spell my name",  Sex="Male",
                    Email="aganmuyi@polychat.com",  RoleId=2,  Password="student"
                },
                new Profile{
                    FirstName="Emmanuel",    LastName="Okwudiri",    About="Easy going Lecturer",  Sex="Male",
                    Email="okwudiri@polychat.com",  RoleId=2,  Password="lecturer"
                },
                new Profile{
                    FirstName="Sonia",    LastName="Eqwitos",    About="Fun loving and high spirited girl",  Sex="female",
                    Email="eqwitos@polychat.com",  RoleId=2,  Password="student"
                },
                new Profile{
                    FirstName="Nnamdi",    LastName="Walter",    About="Mention Code, That is how they spell my name",  Sex="Male",
                    Email="walter@polychat.com",  RoleId=2,  Password="student"
                }
            };

            int counter = 0;
            foreach (var dep in context.Departments) {
                while (counter < profiles.Count) {
                    dep.Profiles.Add(profiles[counter]);
                    counter++;
                    if (counter % 3 == 0) { break; }
                }
            }
            context.SaveChanges();
        }

        private static void populateMessage(InitialzrContext context) {
            var masterList = new List<Profile>();
            var subList = new List<Profile>();

            foreach (var item in context.Profiles) {
                masterList.Add(item);
            }

            foreach (var item in context.Profiles.AsNoTracking()) {
                subList.Add(item);
            }

            foreach (var item in masterList) {
                var me = subList.Find(el => el.Id == item.Id);
                subList.Remove(me);

                foreach (var item2 in subList) {
                    var secItem = masterList.Find(el => el.Id == item2.Id);
                    var msg = new Message {
                        LastMessageDate = DateTime.Now,
                        Participants = new List<Profile> { item, secItem }
                    };

                    msg.Discussion = new List<MessageDiscussion>{
                        new MessageDiscussion{Date =DateTime.Now, Note = "Hello "+ secItem.FirstName+  ", We are chattin!", Profile = item},
                        new MessageDiscussion{Date =DateTime.Now, Note = "Hello "+ item.FirstName+ ", We are chatting!, Yipee!!!", Profile = secItem}
                    };
                    context.Messages.Add(msg);
                }
            }
            context.SaveChanges();
        }

        private static void populatePost(InitialzrContext context) {
            foreach (var item in context.Profiles) {
                item.Post = new List<Post> {
                    new Post {
                        PostDate = DateTime.Now,
                        Content="this is a great day for all of us",
                        ContentType = 1,
                        Discussion = new List<PostDiscussion>{
                            new PostDiscussion{
                                Note="Just like abc",
                                Date = DateTime.Now,
                                Poster = item.FirstName + " " + item.LastName
                            }
                        }
                    }
                };
            }
            context.SaveChanges();
        }

        private static void populateChat(InitialzrContext context) {
            foreach (var dep in context.Departments) {
                dep.Discussion = new List<ChatDiscussion>();

                foreach (var pro in dep.Profiles) {
                    var cht = new ChatDiscussion {
                        Note = pro.FirstName + " says hello " + dep.Title,
                        Date = DateTime.Now,
                        Profile = pro
                    };
                    dep.Discussion.Add(cht);
                }
            }
            context.SaveChanges();
        }
    }
}