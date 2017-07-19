/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [Pressford]
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeId], [UserName], [FirstName], [LastName], [MaxLikesPerMonth]) VALUES (1, N'DAVE@MRMANTON.COM', N'Dave', N'Manton', 5)
INSERT [dbo].[Employees] ([EmployeeId], [UserName], [FirstName], [LastName], [MaxLikesPerMonth]) VALUES (2, N'USER1@TEST.COM', N'User1', N'Test', 5)
INSERT [dbo].[Employees] ([EmployeeId], [UserName], [FirstName], [LastName], [MaxLikesPerMonth]) VALUES (3, N'MORGAN.FREEMAN@TEST.COM', N'Morgan', N'Freeman', 5)
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([ArticleId], [CreatedDate], [AuthorId], [Title], [Summary], [Body], [PublishedDate]) VALUES (1, CAST(N'2017-07-11T20:49:20.160' AS DateTime), 1, N'Star Trek', N'Star Trek Lorem Ipsum', N'<p>[repeated line] Capt. Picard: Tea, Earl Grey, hot.</p>
<p>Gowron: Think of it! Five years ago no one had ever heard of Bajor or Deep Space Nine, and now, all our hopes rest here!</p>
<p>Lieutenant Worf: Mute.</p>
<p>The Doctor:</p>
<p>The Borg: party-poopers of the galaxy. [In reference to the Qomar]</p>
<p>Tuvok: They are interfering with normal ship business.</p>
<p>Captain Janeway: Since when has business on this ship ever been normal?</p>', CAST(N'2017-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Articles] ([ArticleId], [CreatedDate], [AuthorId], [Title], [Summary], [Body], [PublishedDate]) VALUES (3, CAST(N'2017-07-19T15:22:34.983' AS DateTime), 1, N'Stargate', N'Stargate Lorem Ipsum', N'<p>Dr. Rodney McKay: I''m not crazy. I just have another consciousness in my brain.</p>
<p>Maj. John Sheppard: So he just looks crazy.</p>
<p>Dr. Rodney McKay: I''m sure I do, but only because Dr. Fumbles McStupid over here was in way over his head!</p>
<p>Carson Beckett M. D.: [sighs] We believe ATA or Ancient Technology Activation is caused by a single gene that''s always on. Instructing various cells in the body to produce a series of proteins and enzymes</p>
<p>[McKay is staring at syringe]</p>
<p>Carson Beckett M. D.: that interact with the skin, the nervous system and the brain. In this case we''re using a mouse retrovirus to deliver the missing gene to your cells.</p>
<p>Dr. Rodney McKay: [Looking worried] A mouse retrovirus?</p>
<p>Carson Beckett M. D.: It''s been deactivated.</p>
<p>Dr. Rodney McKay: Well, are there any side effects?</p>
<p>Carson Beckett M. D.: Dry mouth, headache, the irresistible urge to run in a small wheel...</p>
<p>Marin: The island is a penal colony. The prisoners usually don''t cause much trouble, as long as you don''t try to land there. Dr. Rodney McKay: Well, you could put up a sign!</p>
<p>Dr. Rodney McKay: So exactly what kind of special training do you guys have to go through to get this sort of mission?</p>
<p>Maj. Lorne: "You guys"?</p>
<p>Dr. Rodney McKay: Yeah, you know - ''Army, Navy, Air Force, Marines. It''s a great place to start''.</p>
<p>Maj. Lorne: And by this mission you mean hunting down a skilled weapons expert hopped up on Wraith drugs, in the pitch black of an alien planet?</p>
<p>Dr. Rodney McKay: Yes.</p>
<p>Maj. Lorne: Actually, I skipped that course in Major school.</p>
<p>Dr. Rodney McKay: I was afraid of that.</p>
<p>Dr. Rodney McKay: I''m picking up a strange reading from right over there.</p>
<p>Maj. John Sheppard: Define strange.</p>
<p>Dr. Rodney McKay: [pause] You don''t know what strange means?</p>', CAST(N'2017-02-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Articles] ([ArticleId], [CreatedDate], [AuthorId], [Title], [Summary], [Body], [PublishedDate]) VALUES (4, CAST(N'2017-07-19T15:23:18.730' AS DateTime), 1, N'Firefly', N'Firefly Lorem Ipsum', N'<p>Jayne Cobb: She is startin'' to damage my calm.</p>
<p>Zo?: Jayne!</p>
<p>Jayne Cobb: She''s *right*! Everybody''s dead!... This whole world is dead for no reason!</p>
<p>Mr. Universe: From here to the eyes and the ears of the ''Verse, that''s my motto, or it might be if I start having a motto.</p>
<p>Capt. Malcolm Reynolds: [after getting punched by Simon] I''m a hairsbreadth from riddlin'' you with holes, Doctor!</p>
<p>Dr. Caron: These are just a few of the images we''ve recorded. And you can see, it wasn''t what we thought. There''s been no war here and no terraforming event. The environment is stable. It''s the Pax. The G-23 Paxilon Hydrochlorate that we added to the air processors. It was supposed to calm the population, weed out aggression. Well, it works. The people here stopped fighting. And then they stopped everything else. They stopped going to work, they stopped breeding, talking, eating. There''s 30 million people here, and they all just let themselves die.</p>
<p>Capt. Malcolm Reynolds: I look to be bored by many more sermons before you slip. Just don''t move.</p>
<p>Shepherd Book: Can''t order me around, boy. I''m not one of your crew.</p>
<p>Capt. Malcolm Reynolds: Yes, you are.</p>', CAST(N'2017-07-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Articles] ([ArticleId], [CreatedDate], [AuthorId], [Title], [Summary], [Body], [PublishedDate]) VALUES (5, CAST(N'2017-07-19T21:03:02.160' AS DateTime), 1, N'Babylon 5', N'Babylon 5 Lorem Ipsum', N'<p>&nbsp;Lennier: [Lennier and Vir do not make eye contact during this conversation] Sometimes I get so close and yet it feels like I''m shut out of the important things. &nbsp;</p>
<p>Ambassador Vir Cotto: It''s a useless feeling. The Ambassador is definitely going through some changes. He even looks different. &nbsp;</p>
<p>Lennier: Indeed. And now with the military starting to stampede over everyone and everything... &nbsp;</p>
<p>Ambassador Vir Cotto: People coming and going and secret meetings... &nbsp;</p>
<p>Lennier: You never know what it''s all about until later when it''s too late. &nbsp;</p>
<p>Ambassador Vir Cotto: And they never listen to us. &nbsp;</p>
<p>Ambassador Vir Cotto, Lennier: Makes me nervous. &nbsp;</p>
<p>Ambassador Vir Cotto: [they finally look at each other] Same time tomorrow? &nbsp;</p>
<p>Lennier: Sure.</p>
<p>Citizen G''Kar: If I take a lamp and shine it toward the wall, a bright spot will appear on the wall. The lamp is our search for truth... for understanding. Too often, we assume that the light on the wall is God, but the light is not the goal of the search, it is the result of the search. The more intense the search, the brighter the light on the wall. The brighter the light on the wall, the greater the sense of revelation upon seeing it. Similarly, someone who does not search - who does not bring a lantern - sees nothing. What we perceive as God is the by-product of our search for God. It may simply be an appreciation of the light... pure and unblemished... not understanding that it comes from us. Sometimes we stand in front of the light and assume that we are the center of the universe - God looks astonishingly like we do - or we turn to look at our shadow and assume that all is darkness. If we allow ourselves to get in the way, we defeat the purpose, which is to use the light of our search to illuminate the wall in all its beauty and in all its flaws; and in so doing, better understand the world around us.</p>
<p>Citizen G''Kar: As the humans say, up yours!</p>
<p>[Opening narration, season 1] &nbsp;</p>
<p>Commander Jeffrey David Sinclair: It was the dawn of the third age of mankind, ten years after the Earth-Minbari War. The Babylon Project was a dream given form. Its goal: to prevent another war by creating a place where humans and aliens could work out their differences peacefully. It''s a port of call, home away from home for diplomats, hustlers, entrepreneurs, and wanderers. Humans and aliens wrapped in two million, five hundred thousand tons of spinning metal, all alone in the night. It can be a dangerous place, but it''s our last, best hope for peace. This is the story of the last of the Babylon stations. The year is 2258. The name of the place is Babylon 5.</p>
<p>Ambassador Londo Mollari: Everyone around me dies, Mr. Morden, except those who most deserve it.</p>
<p>&nbsp;</p>', CAST(N'2017-06-07T00:00:00.000' AS DateTime))
INSERT [dbo].[Articles] ([ArticleId], [CreatedDate], [AuthorId], [Title], [Summary], [Body], [PublishedDate]) VALUES (6, CAST(N'2017-07-19T21:04:36.577' AS DateTime), 1, N'Battlestar Galactica', N'BattleStar Galactica Lorem Ipsum', N'<p>&nbsp;[when Starbuck has landed in the Cylon ship] &nbsp;</p>
<p>Captain Lee ''Apollo'' Adama: Boy, when you take a souvenir, you don''t screw around.</p>
<p>Captain Lee ''Apollo'' Adama: So... um... that bum knee of yours is looking pretty good. And the other one''s not too bad either. &nbsp;</p>
<p>Lt. Kara ''Starbuck'' Thrace: Lee, if you want to ask me to dance, just ask. &nbsp;</p>
<p>Captain Lee ''Apollo'' Adama: You want to dance? &nbsp;</p>
<p>Lt. Kara ''Starbuck'' Thrace: Me in a dress is a once in a lifetime opportunity.</p>
<p>Commander William Adama: There''s a reason you separate military and the police. One fights the enemies of the state, the other serves and protects the people. When the military becomes both, then the enemies of the state tend to become the people.</p>
<p>Doctor Gaius Baltar: All right, that''s it! No more Mr. Nice Gaius!</p>
<p>Captain Lee ''Apollo'' Adama: [in a deleted scene after Laura Roslin asked him if what she did was a mistake] I believe that it is never a mistake to follow your heart.</p>
<p>&nbsp;</p>', CAST(N'2017-05-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Articles] ([ArticleId], [CreatedDate], [AuthorId], [Title], [Summary], [Body], [PublishedDate]) VALUES (7, CAST(N'2017-07-19T21:22:13.203' AS DateTime), 3, N'Futurama', N'Futurama Lorem Ipsum', N'<h1 style="box-sizing: inherit; margin: 0em 0px 0.5em; font-family: ''Roboto Slab'', ''Helvetica Neue'', sans-serif; line-height: 1.25; padding: 0em; min-height: 1rem; color: rgba(0, 0, 0, 0.8);">Why am I sticky and naked? Did I miss something fun?</h1>
<p style="box-sizing: inherit; margin: 0px 0px 0.5em; line-height: 1.5; font-size: 1.25em; color: rgba(0, 0, 0, 0.8); font-family: Roboto, ''Helvetica Neue'', sans-serif;">Too much work. Let''s burn it and say we dumped it in the sewer. Why did you bring us here? Good news, everyone! I''ve taught the toaster to feel love! Interesting. No, wait, the other thing: tedious. I saw you with those two "ladies of the evening" at Elzars. Explain that.</p>
<p style="box-sizing: inherit; margin: 0px 0px 0.5em; line-height: 1.5; color: rgba(0, 0, 0, 0.8); font-family: Roboto, ''Helvetica Neue'', sans-serif; font-size: 16px;">I''m sorry, guys. I never meant to hurt you. Just to destroy everything you ever believed in. Yes. You gave me a dollar and some candy.&nbsp;<strong style="box-sizing: inherit;">Noooooo!</strong>&nbsp;<em style="box-sizing: inherit;">You guys go on without me!</em>&nbsp;I''m going to go&hellip; look for more stuff to steal!</p>
<h2 style="box-sizing: inherit; font-family: ''Roboto Slab'', ''Helvetica Neue'', sans-serif; line-height: 1.5; margin: 0px 0px 0.5em; padding: 0em; color: rgba(0, 0, 0, 0.8);">Oh, but you can. But you may have to metaphorically make a deal with the devil. And by "devil", I mean Robot Devil. And by "metaphorically", I mean get your coat.</h2>
<p style="box-sizing: inherit; margin: 0px 0px 0.5em; line-height: 1.5; color: rgba(0, 0, 0, 0.8); font-family: Roboto, ''Helvetica Neue'', sans-serif; font-size: 16px;">Oh, how I wish I could believe or understand that! There''s only one reasonable course of action now: kill Flexo! Leela, Bender, we''re going grave robbing. Does anybody else feel jealous and aroused and worried?</p>
<ol style="box-sizing: inherit; color: rgba(0, 0, 0, 0.8); font-family: Roboto, ''Helvetica Neue'', sans-serif; font-size: 16px;">
<li style="box-sizing: inherit; font-size: 1em; line-height: 1.5em; margin-bottom: 0.5em;">Leela''s gonna kill me.</li>
<li style="box-sizing: inherit; font-size: 1em; line-height: 1.5em; margin-bottom: 0.5em;">Anyhoo, your net-suits will allow you to experience Fry''s worm infested bowels as if you were actually wriggling through them.</li>
<li style="box-sizing: inherit; font-size: 1em; line-height: 1.5em; margin-bottom: 0.5em;">Oh, you''re a dollar naughtier than most.</li>
</ol>
<h3 style="box-sizing: inherit; font-family: ''Roboto Slab'', ''Helvetica Neue'', sans-serif; line-height: 1.33em; margin: calc(2rem - 0.165em) 0em 1rem; padding: 0em; font-size: 1.28rem; color: rgba(0, 0, 0, 0.8);">Oh, you''re a dollar naughtier than most.</h3>
<p style="box-sizing: inherit; margin: 0px 0px 0.5em; line-height: 1.5; color: rgba(0, 0, 0, 0.8); font-family: Roboto, ''Helvetica Neue'', sans-serif; font-size: 16px;">So, how ''bout them Knicks? Is that a cooking show? Yes, if you make it look like an electrical fire. When you do things right, people won''t be sure you''ve done anything at all. Too much work. Let''s burn it and say we dumped it in the sewer.</p>
<ul style="box-sizing: inherit; color: rgba(0, 0, 0, 0.8); font-family: Roboto, ''Helvetica Neue'', sans-serif; font-size: 16px;">
<li style="box-sizing: inherit; font-size: 1em; line-height: 1.5em; margin-bottom: 0.5em;">Ok, we''ll go deliver this crate like professionals, and then we''ll go ride the bumper cars.</li>
<li style="box-sizing: inherit; font-size: 1em; line-height: 1.5em; margin-bottom: 0.5em;">Man, I''m sore all over. I feel like I just went ten rounds with mighty Thor.</li>
<li style="box-sizing: inherit; font-size: 1em; line-height: 1.5em; margin-bottom: 0.5em;">Tell her she looks thin.</li>
</ul>', CAST(N'2017-06-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Articles] ([ArticleId], [CreatedDate], [AuthorId], [Title], [Summary], [Body], [PublishedDate]) VALUES (8, CAST(N'2017-07-19T21:24:14.567' AS DateTime), 3, N'Zombies', N'Zombie Lorem Ipsum', N'<p>Zombie ipsum reversus ab viral inferno, nam rick grimes malum cerebro. De carne lumbering animata corpora quaeritis. Summus brains sit??, morbo vel maleficia? De apocalypsi gorger omero undead survivor dictum mauris. Hi mindless mortuis soulless creaturas, imo evil stalking monstra adventus resi dentevil vultus comedat cerebella viventium. Qui animated corpse, cricket bat max brucks terribilem incessu zomby. The voodoo sacerdos flesh eater, suscitat mortuos comedere carnem virus. Zonbi tattered for solum oculi eorum defunctis go lum cerebro. Nescio brains an Undead zombies. Sicut malus putrid voodoo horror. Nigh tofth eliv ingdead.</p>', CAST(N'2017-02-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Articles] ([ArticleId], [CreatedDate], [AuthorId], [Title], [Summary], [Body], [PublishedDate]) VALUES (9, CAST(N'2017-07-19T21:27:16.383' AS DateTime), 3, N'Moby Dick', N'Moby Dick Lorem Ipsum', N'<p>Some hours after midnight, the Typhoon abated so much, that through the strenuous exertions of Starbuck and Stubb&mdash;one engaged forward and the other aft&mdash;the shivered remnants of the jib and fore and main-top-sails were cut adrift from the spars, and went eddying away to leeward, like the feathers of an albatross, which sometimes are cast to the winds when that storm-tossed bird is on the wing.</p>
<p>The three corresponding new sails were now bent and reefed, and a storm-trysail was set further aft; so that the ship soon went through the water with some precision again; and the course&mdash;for the present, East-south-east&mdash;which he was to steer, if practicable, was once more given to the helmsman. For during the violence of the gale, he had only steered according to its vicissitudes. But as he was now bringing the ship as near her course as possible, watching the compass meanwhile, lo! a good sign! the wind seemed coming round astern; aye, the foul breeze became fair!</p>
<p>Instantly the yards were squared, to the lively song of "HO! THE FAIR WIND! OH-YE-HO, CHEERLY MEN!" the crew singing for joy, that so promising an event should so soon have falsified the evil portents preceding it.</p>
<p>In compliance with the standing order of his commander&mdash;to report immediately, and at any one of the twenty-four hours, any decided change in the affairs of the deck,&mdash;Starbuck had no sooner trimmed the yards to the breeze&mdash;however reluctantly and gloomily,&mdash;than he mechanically went below to apprise Captain Ahab of the circumstance.</p>', CAST(N'2017-01-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Articles] ([ArticleId], [CreatedDate], [AuthorId], [Title], [Summary], [Body], [PublishedDate]) VALUES (10, CAST(N'2017-07-19T21:28:18.717' AS DateTime), 3, N'Wizard of Oz', N'Wizardy Lorem Ipsum', N'<p>Of course each one of them expected to see the Wizard in the shape he had taken before, and all were greatly surprised when they looked about and saw no one at all in the room. They kept close to the door and closer to one another, for the stillness of the empty room was more dreadful than any of the forms they had seen Oz take.</p>
<p>Presently they heard a solemn Voice, that seemed to come from somewhere near the top of the great dome, and it said:</p>
<p>"I am Oz, the Great and Terrible. Why do you seek me?"</p>
<p>They looked again in every part of the room, and then, seeing no one, Dorothy asked, "Where are you?"</p>
<p>"I am everywhere," answered the Voice, "but to the eyes of common mortals I am invisible. I will now seat myself upon my throne, that you may converse with me." Indeed, the Voice seemed just then to come straight from the throne itself; so they walked toward it and stood in a row while Dorothy said:</p>', CAST(N'2017-07-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Articles] ([ArticleId], [CreatedDate], [AuthorId], [Title], [Summary], [Body], [PublishedDate]) VALUES (11, CAST(N'2017-07-19T21:29:12.850' AS DateTime), 3, N'Alice in Wonderland', N'Wonderland Lorem Ipsum', N'<p>''You couldn''t have wanted it much,'' said Alice; ''living at the bottom of the sea.''</p>
<p>''I couldn''t afford to learn it.'' said the Mock Turtle with a sigh. ''I only took the regular course.''</p>
<p>''What was that?'' inquired Alice.</p>
<p>''Reeling and Writhing, of course, to begin with,'' the Mock Turtle replied; ''and then the different branches of Arithmetic&mdash;Ambition, Distraction, Uglification, and Derision.''</p>
<p>''I never heard of "Uglification,"'' Alice ventured to say. ''What is it?''</p>', CAST(N'2017-03-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Articles] ([ArticleId], [CreatedDate], [AuthorId], [Title], [Summary], [Body], [PublishedDate]) VALUES (12, CAST(N'2017-07-19T21:30:00.333' AS DateTime), 3, N'Around the World in 80 days', N'Geography Lorem Ipsum', N'<p>"No doubt, for he is carrying an enormous sum in brand new banknotes with him. And he doesn''t spare the money on the way, either: he has offered a large reward to the engineer of the Mongolia if he gets us to Bombay well in advance of time."</p>
<p>"And you have known your master a long time?"</p>
<p>"Why, no; I entered his service the very day we left London."</p>
<p>The effect of these replies upon the already suspicious and excited detective may be imagined. The hasty departure from London soon after the robbery; the large sum carried by Mr. Fogg; his eagerness to reach distant countries; the pretext of an eccentric and foolhardy bet&mdash;all confirmed Fix in his theory. He continued to pump poor Passepartout, and learned that he really knew little or nothing of his master, who lived a solitary existence in London, was said to be rich, though no one knew whence came his riches, and was mysterious and impenetrable in his affairs and habits. Fix felt sure that Phileas Fogg would not land at Suez, but was really going on to Bombay.</p>
<p>"Is Bombay far from here?" asked Passepartout.</p>
<p>"Pretty far. It is a ten days'' voyage by sea."</p>
<p>"And in what country is Bombay?"</p>', CAST(N'2017-07-14T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Articles] OFF
INSERT [dbo].[ArticleLikes] ([ArticleId], [EmployeeId], [CreatedDate]) VALUES (1, 1, CAST(N'2017-07-19T21:31:48.173' AS DateTime))
INSERT [dbo].[ArticleLikes] ([ArticleId], [EmployeeId], [CreatedDate]) VALUES (1, 3, CAST(N'2017-07-19T21:20:44.760' AS DateTime))
INSERT [dbo].[ArticleLikes] ([ArticleId], [EmployeeId], [CreatedDate]) VALUES (3, 1, CAST(N'2017-07-19T21:31:52.667' AS DateTime))
INSERT [dbo].[ArticleLikes] ([ArticleId], [EmployeeId], [CreatedDate]) VALUES (3, 2, CAST(N'2017-07-19T21:31:20.957' AS DateTime))
INSERT [dbo].[ArticleLikes] ([ArticleId], [EmployeeId], [CreatedDate]) VALUES (3, 3, CAST(N'2017-07-19T21:20:48.700' AS DateTime))
INSERT [dbo].[ArticleLikes] ([ArticleId], [EmployeeId], [CreatedDate]) VALUES (4, 1, CAST(N'2017-07-19T18:45:35.150' AS DateTime))
INSERT [dbo].[ArticleLikes] ([ArticleId], [EmployeeId], [CreatedDate]) VALUES (4, 2, CAST(N'2017-07-19T21:31:17.000' AS DateTime))
INSERT [dbo].[ArticleLikes] ([ArticleId], [EmployeeId], [CreatedDate]) VALUES (4, 3, CAST(N'2017-07-19T21:20:54.023' AS DateTime))
INSERT [dbo].[ArticleLikes] ([ArticleId], [EmployeeId], [CreatedDate]) VALUES (6, 1, CAST(N'2017-07-19T21:31:34.720' AS DateTime))
INSERT [dbo].[ArticleLikes] ([ArticleId], [EmployeeId], [CreatedDate]) VALUES (6, 2, CAST(N'2017-07-19T21:31:11.187' AS DateTime))
INSERT [dbo].[ArticleLikes] ([ArticleId], [EmployeeId], [CreatedDate]) VALUES (6, 3, CAST(N'2017-07-19T21:21:08.420' AS DateTime))
INSERT [dbo].[ArticleLikes] ([ArticleId], [EmployeeId], [CreatedDate]) VALUES (7, 3, CAST(N'2017-07-19T21:30:30.443' AS DateTime))
INSERT [dbo].[ArticleLikes] ([ArticleId], [EmployeeId], [CreatedDate]) VALUES (8, 1, CAST(N'2017-07-19T21:32:02.377' AS DateTime))
