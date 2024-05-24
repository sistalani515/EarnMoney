using Newtonsoft.Json;

namespace EarnMoney.Models.Requests.WhatsApp
{
    public class WhatsAppReqBody
    {
        [JsonProperty("ts")]
        public long Ts;

        [JsonProperty("sessionId")]
        public string? SessionId;

        [JsonProperty("id")]
        public string? Id;

        [JsonProperty("event")]
        public string? Event;

        [JsonProperty("data")]
        public Data? Data;

        [JsonProperty("webhook_id")]
        public string? WebhookId;
    }

    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class ScansSidecar
    {
    }

    public class ProfilePicThumbObj
    {
        [JsonProperty("eurl")]
        public object? Eurl;

        [JsonProperty("id")]
        public string? Id;

        [JsonProperty("tag")]
        public object? Tag;
    }

    public class Sender
    {
        [JsonProperty("id")]
        public string? Id;

        [JsonProperty("name")]
        public string? Name;

        [JsonProperty("shortName")]
        public string? ShortName;

        [JsonProperty("pushname")]
        public string? Pushname;

        [JsonProperty("type")]
        public string? Type;

        [JsonProperty("isBusiness")]
        public bool? IsBusiness;

        [JsonProperty("isEnterprise")]
        public bool? IsEnterprise;

        [JsonProperty("labels")]
        public List<object>? Labels;

        [JsonProperty("isContactSyncCompleted")]
        public int IsContactSyncCompleted;

        [JsonProperty("disappearingModeDuration")]
        public int DisappearingModeDuration;

        [JsonProperty("disappearingModeSettingTimestamp")]
        public int DisappearingModeSettingTimestamp;

        [JsonProperty("formattedName")]
        public string? FormattedName;

        [JsonProperty("isMe")]
        public bool? IsMe;

        [JsonProperty("isMyContact")]
        public bool? IsMyContact;

        [JsonProperty("isPSA")]
        public bool? IsPSA;

        [JsonProperty("isUser")]
        public bool? IsUser;

        [JsonProperty("isWAContact")]
        public bool? IsWAContact;

        [JsonProperty("profilePicThumbObj")]
        public ProfilePicThumbObj? ProfilePicThumbObj;

        [JsonProperty("msgs")]
        public object? Msgs;
    }

    public class LastReceivedKey
    {
        [JsonProperty("fromMe")]
        public bool? FromMe;

        [JsonProperty("remote")]
        public string? Remote;

        [JsonProperty("id")]
        public string? Id;

        [JsonProperty("participant")]
        public string? Participant;

        [JsonProperty("_serialized")]
        public string? Serialized;
    }

    public class Contact
    {
        [JsonProperty("id")]
        public string? Id;

        [JsonProperty("name")]
        public string? Name;
        [JsonProperty("pushname")]
        public string? Pushname;

        [JsonProperty("type")]
        public string? Type;

        [JsonProperty("labels")]
        public List<object>? Labels;

        [JsonProperty("formattedName")]
        public string? FormattedName;

        [JsonProperty("isMe")]
        public bool? IsMe;

        [JsonProperty("isMyContact")]
        public bool? IsMyContact;

        [JsonProperty("isPSA")]
        public bool? IsPSA;

        [JsonProperty("isUser")]
        public bool? IsUser;

        [JsonProperty("isWAContact")]
        public bool? IsWAContact;

        [JsonProperty("profilePicThumbObj")]
        public ProfilePicThumbObj? ProfilePicThumbObj;

        [JsonProperty("msgs")]
        public object? Msgs;
    }

    public class UniqueShortNameMap
    {
    }

    public class Participant
    {
        [JsonProperty("id")]
        public string? Id;

        [JsonProperty("isAdmin")]
        public bool? IsAdmin;

        [JsonProperty("isSuperAdmin")]
        public bool? IsSuperAdmin;
    }

    public class GroupMetadata
    {
        [JsonProperty("id")]
        public string? Id;

        [JsonProperty("creation")]
        public int Creation;

        [JsonProperty("owner")]
        public string? Owner;

        [JsonProperty("descTime")]
        public int DescTime;

        [JsonProperty("restrict")]
        public bool? Restrict;

        [JsonProperty("announce")]
        public bool? Announce;

        [JsonProperty("noFrequentlyForwarded")]
        public bool? NoFrequentlyForwarded;

        [JsonProperty("support")]
        public bool? Support;

        [JsonProperty("suspended")]
        public bool? Suspended;

        [JsonProperty("terminated")]
        public bool? Terminated;

        [JsonProperty("uniqueShortNameMap")]
        public UniqueShortNameMap? UniqueShortNameMap;

        [JsonProperty("isParentGroup")]
        public bool? IsParentGroup;

        [JsonProperty("defaultSubgroup")]
        public bool? DefaultSubgroup;

        [JsonProperty("unjoinedSubgroups")]
        public List<object>? UnjoinedSubgroups;

        [JsonProperty("notAddedByContact")]
        public bool? NotAddedByContact;

        [JsonProperty("participants")]
        public List<Participant>? Participants;

        [JsonProperty("pendingParticipants")]
        public List<object>? PendingParticipants;
    }

    public class Chatstate
    {
        [JsonProperty("id")]
        public string? Id;
    }

    public class Presence
    {
        [JsonProperty("id")]
        public string? Id;

        [JsonProperty("chatstates")]
        public List<Chatstate>? Chatstates;
    }

    public class Chat
    {
        [JsonProperty("id")]
        public string? Id;

        [JsonProperty("labels")]
        public List<object>? Labels;

        [JsonProperty("lastReceivedKey")]
        public LastReceivedKey? LastReceivedKey;

        [JsonProperty("t")]
        public int T;

        [JsonProperty("unreadCount")]
        public int UnreadCount;

        [JsonProperty("isReadOnly")]
        public bool? IsReadOnly;

        [JsonProperty("isAnnounceGrpRestrict")]
        public bool? IsAnnounceGrpRestrict;

        [JsonProperty("muteExpiration")]
        public int MuteExpiration;

        [JsonProperty("name")]
        public string? Name;

        [JsonProperty("hasUnreadMention")]
        public bool? HasUnreadMention;

        [JsonProperty("archiveAtMentionViewedInDrawer")]
        public bool? ArchiveAtMentionViewedInDrawer;

        [JsonProperty("hasChatBeenOpened")]
        public bool? HasChatBeenOpened;

        [JsonProperty("pendingInitialLoading")]
        public bool? PendingInitialLoading;

        [JsonProperty("msgs")]
        public object? Msgs;

        [JsonProperty("kind")]
        public string? Kind;

        [JsonProperty("canSend")]
        public bool? CanSend;

        [JsonProperty("isGroup")]
        public bool? IsGroup;

        [JsonProperty("formattedTitle")]
        public string? FormattedTitle;

        [JsonProperty("contact")]
        public Contact? Contact;

        [JsonProperty("groupMetadata")]
        public GroupMetadata? GroupMetadata;

        [JsonProperty("presence")]
        public Presence? Presence;

        [JsonProperty("isOnline")]
        public bool? IsOnline;

        [JsonProperty("participantsCount")]
        public int ParticipantsCount;
    }

    public class MediaData
    {
        [JsonProperty("type")]
        public string? Type;

        [JsonProperty("mediaStage")]
        public string? MediaStage;

        [JsonProperty("animationDuration")]
        public int AnimationDuration;

        [JsonProperty("animatedAsNewMsg")]
        public bool? AnimatedAsNewMsg;

        [JsonProperty("isViewOnce")]
        public bool? IsViewOnce;

        [JsonProperty("_swStreamingSupported")]
        public bool? SwStreamingSupported;

        [JsonProperty("_listeningToSwSupport")]
        public bool? ListeningToSwSupport;

        [JsonProperty("isVcardOverMmsDocument")]
        public bool? IsVcardOverMmsDocument;
    }

    public class Data
    {
        [JsonProperty("id")]
        public string? Id;

        [JsonProperty("body")]
        public string? Body;

        [JsonProperty("type")]
        public string? Type;

        [JsonProperty("t")]
        public int T;

        [JsonProperty("notifyName")]
        public string? NotifyName;

        [JsonProperty("from")]
        public string? From;

        [JsonProperty("to")]
        public string? To;

        [JsonProperty("author")]
        public string? Author;

        [JsonProperty("self")]
        public string? Self;

        [JsonProperty("ack")]
        public int Ack;

        [JsonProperty("isNewMsg")]
        public bool? IsNewMsg;

        [JsonProperty("star")]
        public bool? Star;

        [JsonProperty("recvFresh")]
        public bool? RecvFresh;

        [JsonProperty("caption")]
        public string? Caption;

        [JsonProperty("interactiveAnnotations")]
        public List<object>? InteractiveAnnotations;

        [JsonProperty("clientUrl")]
        public string? ClientUrl;

        [JsonProperty("deprecatedMms3Url")]
        public string? DeprecatedMms3Url;

        [JsonProperty("directPath")]
        public string? DirectPath;

        [JsonProperty("mimetype")]
        public string? Mimetype;

        [JsonProperty("filehash")]
        public string? Filehash;

        [JsonProperty("encFilehash")]
        public string? EncFilehash;

        [JsonProperty("size")]
        public int Size;

        [JsonProperty("mediaKey")]
        public string? MediaKey;

        [JsonProperty("mediaKeyTimestamp")]
        public int MediaKeyTimestamp;

        [JsonProperty("isViewOnce")]
        public bool? IsViewOnce;

        [JsonProperty("width")]
        public int Width;

        [JsonProperty("height")]
        public int Height;

        [JsonProperty("staticUrl")]
        public string? StaticUrl;

        [JsonProperty("scanLengths")]
        public List<int>? ScanLengths;

        [JsonProperty("scansSidecar")]
        public ScansSidecar? ScansSidecar;

        [JsonProperty("isFromTemplate")]
        public bool? IsFromTemplate;

        [JsonProperty("broadcast")]
        public bool? Broadcast;

        [JsonProperty("quotedMsg")]
        public object? QuotedMsg;

        [JsonProperty("mentionedJidList")]
        public List<object>? MentionedJidList;

        [JsonProperty("isVcardOverMmsDocument")]
        public bool? IsVcardOverMmsDocument;

        [JsonProperty("isForwarded")]
        public bool? IsForwarded;

        [JsonProperty("labels")]
        public List<object>? Labels;

        [JsonProperty("hasReaction")]
        public bool? HasReaction;

        [JsonProperty("productHeaderImageRejected")]
        public bool? ProductHeaderImageRejected;

        [JsonProperty("lastPlaybackProgress")]
        public int LastPlaybackProgress;

        [JsonProperty("isDynamicReplyButtonsMsg")]
        public bool? IsDynamicReplyButtonsMsg;

        [JsonProperty("isMdHistoryMsg")]
        public bool? IsMdHistoryMsg;

        [JsonProperty("requiresDirectConnection")]
        public bool? RequiresDirectConnection;

        [JsonProperty("pttForwardedFeaturesEnabled")]
        public bool? PttForwardedFeaturesEnabled;

        [JsonProperty("fromMe")]
        public bool? FromMe;

        [JsonProperty("sender")]
        public Sender? Sender;

        [JsonProperty("timestamp")]
        public int Timestamp;

        [JsonProperty("content")]
        public string? Content;

        [JsonProperty("isGroupMsg")]
        public bool? IsGroupMsg;

        [JsonProperty("isMedia")]
        public bool? IsMedia;

        [JsonProperty("isNotification")]
        public bool? IsNotification;

        [JsonProperty("isPSA")]
        public bool? IsPSA;

        [JsonProperty("chat")]
        public Chat? Chat;

        [JsonProperty("isOnline")]
        public bool? IsOnline;

        [JsonProperty("chatId")]
        public string? ChatId;

        [JsonProperty("quotedMsgObj")]
        public object? QuotedMsgObj;

        [JsonProperty("mediaData")]
        public MediaData? MediaData;

        [JsonProperty("text")]
        public string? Text;
    }
}
