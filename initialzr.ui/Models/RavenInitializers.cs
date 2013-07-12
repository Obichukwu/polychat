//using initialzr.ui.Models;
//using Raven.Client;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;

//namespace initialzr.ui.Models {
//    public class RavenInitializers {
//        public static void Seed(IDocumentSession context) {
//            populateFaculty(context);
//            populateDepartment(context);
//            populateProfile(context);
//            populateMessage(context);
//            populatePost(context);
//            populateChat(context);
//        }

//        private static void populateFaculty(IDocumentSession context) {
//            var faculties = new List<Faculty> {
//                new Faculty{
//                    Title="Science and Technology",
//                    Description ="SST",
//                    Departments = new List<Department>()
//                },
//                new Faculty{
//                    Title="Engineering and Environmental Studies",
//                    Description ="SST",
//                    Departments = new List<Department>()
//                },
//                new Faculty{
//                    Title="Business",
//                    Description ="SST",
//                    Departments = new List<Department>()
//                }
//            };
//            faculties.ForEach(ur => context.Store(ur));
//            context.SaveChanges();
//        }

//        private static void populateDepartment(IDocumentSession context) {
//            var departments = new List<Department> {
//                new Department{
//                    Title="Computer Science",
//                    Description="CS",
//                    Profiles= new List<Profile>()
//                },
//                new Department{
//                    Title="Mathematics and Statistics",
//                    Description="M&S",
//                    Profiles= new List<Profile>()
//                },
//                new Department{
//                    Title="Science Laboratory Technology",
//                    Description="SLT",
//                    Profiles= new List<Profile>()
//                },
//                new Department{
//                    Title="Building Technology",
//                    Description="Building",
//                    Profiles= new List<Profile>()
//                },
//                new Department{
//                    Title="Civil Engineering",
//                    Description="Civil",
//                    Profiles= new List<Profile>()
//                },
//                new Department{
//                    Title="Office Technology and Management",
//                    Description="OTM",
//                    Profiles= new List<Profile>()
//                },
//                new Department{
//                    Title="Business Administration",
//                    Description="BA",
//                    Profiles= new List<Profile>()
//                },
//                new Department{
//                    Title="Banking and Finance",
//                    Description="B&F",
//                    Profiles= new List<Profile>()
//                }
//            };

//            int counter = 0;
//            foreach (var fac in context.Query<Faculty>().ToList()) {
//                while (counter < departments.Count) {
//                    context.Store(departments[counter]);
//                    fac.Departments.Add(departments[counter]);
//                    counter++;
//                    if (counter % 3 == 0) { break; }
//                }
//            }
//            context.SaveChanges();
//        }

//        private static void populateProfile(IDocumentSession context) {
//            var profiles = new List<Profile>{
//                new Profile{
//                    FirstName="Wilfred",    LastName="Adigwe",    About="Easy going Lecturer",  Sex="Male",
//                    Email="adigwe@initialzr.com", RoleId=2, IsAdmin=true, Password="lecturer",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Christabel",    LastName="Ika",    About="Fun loving and high spirited girl",  Sex="female",
//                    Email="ika@initialzr.com",   RoleId=2, IsAdmin=false, Password="student",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="John",    LastName="Ufouma",    About="Mention Code, That is how they spell my name",  Sex="Male",
//                    Email="ufouma@initialzr.com", RoleId=2, IsAdmin=false, Password="student",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Ese",    LastName="Iteveh",    About="Easy going Lecturer",  Sex="Male",
//                    Email="iteveh@initialzr.com",  RoleId=2, IsAdmin=true, Password="lecturer",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Harriet",    LastName="Okoro",    About="Fun loving and high spirited girl",  Sex="female",
//                    Email="okoro@initialzr.com",  RoleId=2, IsAdmin=false, Password="student",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="John",    LastName="Edafe",    About="Mention Code, That is how they spell my name",  Sex="Male",
//                    Email="edafe@initialzr.com",  RoleId=2, IsAdmin=false, Password="student",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Winifred",    LastName="Adigi",    About="Easy going Lecturer",  Sex="Male",
//                    Email="adigi@initialzr.com",  RoleId=2, IsAdmin=true, Password="lecturer",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Rita",    LastName="Okwuguni",    About="Fun loving and high spirited girl",  Sex="female",
//                    Email="okuguni@initialzr.com",  RoleId=2, IsAdmin=false, Password="student",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Christopher",    LastName="Udeme",    About="Mention Code, That is how they spell my name",  Sex="Male",
//                    Email="udeme@initialzr.com",  RoleId=2, IsAdmin=false, Password="student",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Alonzo",    LastName="Aristos",    About="Easy going Lecturer",  Sex="Male",
//                    Email="aristos@initialzr.com",  RoleId=2, IsAdmin=true, Password="lecturer",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Charity",    LastName="Uyimeh",    About="Fun loving and high spirited girl",  Sex="female",
//                    Email="uyimeh@initialzr.com",  RoleId=2, IsAdmin=false, Password="student",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="James",    LastName="Pela",    About="Mention Code, That is how they spell my name",  Sex="Male",
//                    Email="pela@initialzr.com",  RoleId=2, IsAdmin=false, Password="student",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Sunday",    LastName="Ifeanyi",    About="Easy going Lecturer",  Sex="Male",
//                    Email="ifeanyi@initialzr.com",  RoleId=2, IsAdmin=true, Password="lecturer",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Jennifer",    LastName="Ekobe",    About="Fun loving and high spirited girl",  Sex="female",
//                    Email="ekobe@initialzr.com",  RoleId=2, IsAdmin=false, Password="student",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Matthew",    LastName="Korrect",    About="Mention Code, That is how they spell my name",  Sex="Male",
//                    Email="korrect@initialzr.com",  RoleId=2, IsAdmin=false, Password="student",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Jessica",    LastName="Amiaya",    About="Easy going Lecturer",  Sex="Female",
//                    Email="amiaya@initialzr.com",  RoleId=2, IsAdmin=true, Password="lecturer",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Sadiya",    LastName="Olaide",    About="Fun loving and high spirited girl",  Sex="female",
//                    Email="olaide@initialzr.com",  RoleId=2, IsAdmin=false, Password="student",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Mohammed",    LastName="Abubakar",    About="Mention Code, That is how they spell my name",  Sex="Male",
//                    Email="abubakar@initialzr.com",  RoleId=2, IsAdmin=false, Password="student",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Tejiri",    LastName="Oke",    About="Easy going Lecturer",  Sex="Male",
//                    Email="oke@initialzr.com",  RoleId=2, IsAdmin=true, Password="lecturer",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Sandra",    LastName="Ibeh",    About="Fun loving and high spirited girl",  Sex="female",
//                    Email="ibeh@initialzr.com",  RoleId=2, IsAdmin=false, Password="student",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Femi",    LastName="Aganmuyi",    About="Mention Code, That is how they spell my name",  Sex="Male",
//                    Email="aganmuyi@initialzr.com",  RoleId=2, IsAdmin=false, Password="student",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Emmanuel",    LastName="Okwudiri",    About="Easy going Lecturer",  Sex="Male",
//                    Email="okwudiri@initialzr.com",  RoleId=2, IsAdmin=true, Password="lecturer",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Sonia",    LastName="Eqwitos",    About="Fun loving and high spirited girl",  Sex="female",
//                    Email="eqwitos@initialzr.com",  RoleId=2, IsAdmin=false, Password="student",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                },
//                new Profile{
//                    FirstName="Nnamdi",    LastName="Walter",    About="Mention Code, That is how they spell my name",  Sex="Male",
//                    Email="walter@initialzr.com",  RoleId=2, IsAdmin=false, Password="student",
//                    Messages=new List<Message>(), Post= new List<Post>(), Image = ""
//                }
//            };

//            int counter = 0;
//            foreach (var dep in context.Query<Department>().ToList()) {
//                while (counter < profiles.Count) {
//                    context.Store(profiles[counter]);
//                    dep.Profiles.Add(profiles[counter]);
//                    counter++;
//                    if (counter % 3 == 0) { break; }
//                }
//            }
//            context.SaveChanges();
//        }

//        private static void populateMessage(IDocumentSession context) {
//            var subList = new List<Profile>();

//            foreach (var item in context.Query<Profile>().ToList()) {
//                subList.Add(item);
//            }

//            foreach (var item in context.Query<Profile>().ToList()) {
//                var me = subList.Find(el => el.Id == item.Id);
//                subList.Remove(me);

//                foreach (var item2 in subList) {
//                    var secItem = context.Load<Profile>(item2.Id);
//                    var msg = new Message {
//                        LastMessageDate = DateTime.Now,
//                        Participants = new List<Profile> { item, secItem }
//                    };

//                    msg.Discussion = new List<MessageDiscussion>{
//                        new MessageDiscussion{Date =DateTime.Now, Note = "Hello "+ secItem.FirstName+  ", We are chattin!", Profile = item},
//                        new MessageDiscussion{Date =DateTime.Now, Note = "Hello "+ item.FirstName+ ", We are chatting!, Yipee!!!", Profile = secItem}
//                    };
//                    context.Store(msg);

//                    item.Messages.Add(msg);
//                    secItem.Messages.Add(msg);
//                }
//            }
//            context.SaveChanges();
//        }

//        private static void populatePost(IDocumentSession context) {
//            foreach (var item in context.Query<Profile>().ToList()) {
//                item.Post = new List<Post> {
//                    new Post {
//                        Title = "The Day",
//                        PostDate = DateTime.Now,
//                        Content="this is a great day for all of us",
//                        ContentType = 1,
//                        Discussion = new List<PostDiscussion>{
//                            new PostDiscussion{
//                                Note="Just like abc",
//                                Date = DateTime.Now,
//                                LikeCount = 5,
//                                Poster = item.FirstName + " " + item.LastName
//                            }
//                        }
//                    }
//                };
//            }
//            context.SaveChanges();
//        }

//        private static void populateChat(IDocumentSession context) {
//            foreach (var fac in context.Query<Faculty>().ToList()) {
//                var parentRoom = new ChatRoom { Title = fac.Title, Description="private room for " + fac.Description, SubRooms = new List<ChatRoom>() };

//                foreach (var dep in fac.Departments) {
//                    var childRoom = new ChatRoom { Title = dep.Title, Description = "private room for " + dep.Description };

//                    childRoom.Discussion = new List<ChatDiscussion>();

//                    foreach (var pro in dep.Profiles) {
//                        var cht = new ChatDiscussion {
//                            Note = pro.FirstName + " says hello " + dep.Title,
//                            Date = DateTime.Now,
//                            Profile = pro
//                        };
//                        childRoom.Discussion.Add(cht);
//                    }
//                    parentRoom.SubRooms.Add(childRoom);
//                };
//                context.Store(parentRoom);
//            }
//            context.SaveChanges();
//        }
//    }
//}