using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace Upio.MyData.BlackBox.Core.Schema;

public sealed partial class ResponseDoc : XTypedElement, IXMetaData {
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XTypedList<ResponseType> responseField;
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static Dictionary<System.Xml.Linq.XName, System.Type> localElementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();
    
    public static explicit operator ResponseDoc(XElement xe) { return XTypedServices.ToXTypedElement<ResponseDoc>(xe,LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }
    
    static ResponseDoc() {
        BuildElementDictionary();
    }
    
    /// <summary>
    /// <para>
    /// Regular expression: (response)+
    /// </para>
    /// </summary>
    public ResponseDoc() {
    }
    
    /// <summary>
    /// <para>
    /// Occurrence: required
    /// </para>
    /// <para>
    /// Regular expression: (response)+
    /// </para>
    /// </summary>
    public IList<ResponseType> response {
        get {
            if ((this.responseField == null)) {
                this.responseField = new XTypedList<ResponseType>(this, LinqToXsdTypeManager.Instance, System.Xml.Linq.XName.Get("response", ""));
            }
            return this.responseField;
        }
        set {
            if ((value == null)) {
                this.responseField = null;
            }
            else {
                if ((this.responseField == null)) {
                    this.responseField = XTypedList<ResponseType>.Initialize(this, LinqToXsdTypeManager.Instance, value, System.Xml.Linq.XName.Get("response", ""));
                }
                else {
                    XTypedServices.SetList<ResponseType>(this.responseField, value);
                }
            }
        }
    }
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    Dictionary<System.Xml.Linq.XName, System.Type> IXMetaData.LocalElementsDictionary {
        get {
            return localElementDictionary;
        }
    }
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    System.Xml.Linq.XName IXMetaData.SchemaName {
        get {
            return System.Xml.Linq.XName.Get("ResponseDoc", "");
        }
    }
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    SchemaOrigin IXMetaData.TypeOrigin {
        get {
            return SchemaOrigin.Element;
        }
    }
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    ILinqToXsdTypeManager IXMetaData.TypeManager {
        get {
            return LinqToXsdTypeManager.Instance;
        }
    }
    
    public void Save(string xmlFile) {
        XTypedServices.Save(xmlFile, Untyped);
    }
    
    public void Save(System.IO.TextWriter tw) {
        XTypedServices.Save(tw, Untyped);
    }
    
    public void Save(System.Xml.XmlWriter xmlWriter) {
        XTypedServices.Save(xmlWriter, Untyped);
    }
    
    public static ResponseDoc Load(string xmlFile) {
        return XTypedServices.Load<ResponseDoc>(xmlFile);
    }
    
    public static ResponseDoc Load(System.IO.TextReader xmlFile) {
        return XTypedServices.Load<ResponseDoc>(xmlFile);
    }
    
    public static ResponseDoc Parse(string xml) {
        return XTypedServices.Parse<ResponseDoc>(xml);
    }
    
    public override XTypedElement Clone() {
        return XTypedServices.CloneXTypedElement<ResponseDoc>(this);
    }
    
    private static void BuildElementDictionary() {
        localElementDictionary.Add(System.Xml.Linq.XName.Get("response", ""), typeof(ResponseType));
    }
    
    ContentModelEntity IXMetaData.GetContentModel() {
        return ContentModelEntity.Default;
    }
}

/// <summary>
/// <para>
/// Regular expression: (index?, ((invoiceUid?, invoiceMark?, classificationMark?, cancellationMark?, authenticationCode?)|errors), statusCode)
/// </para>
/// </summary>
public partial class ResponseType : XTypedElement, IXMetaData {
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static Dictionary<System.Xml.Linq.XName, System.Type> localElementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();
    
    public static explicit operator ResponseType(XElement xe) { return XTypedServices.ToXTypedElement<ResponseType>(xe,LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }
    
    static ResponseType() {
        BuildElementDictionary();
    }
    
    /// <summary>
    /// <para>
    /// Regular expression: (index?, ((invoiceUid?, invoiceMark?, classificationMark?, cancellationMark?, authenticationCode?)|errors), statusCode)
    /// </para>
    /// </summary>
    public ResponseType() {
    }
    
    /// <summary>
    /// <para>
    /// ΑΑ γραμμής οντότητας
    /// </para>
    /// <para>
    /// Occurrence: optional
    /// </para>
    /// <para>
    /// Regular expression: (index?, ((invoiceUid?, invoiceMark?, classificationMark?, cancellationMark?, authenticationCode?)|errors), statusCode)
    /// </para>
    /// </summary>
    public virtual System.Nullable<int> index {
        get {
            XElement x = this.GetElement(System.Xml.Linq.XName.Get("index", ""));
            if ((x == null)) {
                return null;
            }
            return XTypedServices.ParseValue<int>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Int).Datatype);
        }
        set {
            this.SetElement(System.Xml.Linq.XName.Get("index", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Int).Datatype);
        }
    }
    
    /// <summary>
    /// <para>
    /// Αναγνωριστικό οντότητας
    /// </para>
    /// <para>
    /// Occurrence: optional
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: (index?, ((invoiceUid?, invoiceMark?, classificationMark?, cancellationMark?, authenticationCode?)|errors), statusCode)
    /// </para>
    /// </summary>
    public virtual string invoiceUid {
        get {
            XElement x = this.GetElement(System.Xml.Linq.XName.Get("invoiceUid", ""));
            return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
        }
        set {
            this.SetElement(System.Xml.Linq.XName.Get("invoiceUid", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
        }
    }
    
    /// <summary>
    /// <para>
    /// Μοναδικός Αριθμός Καταχώρησης παραστατικού
    /// </para>
    /// <para>
    /// Occurrence: optional
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: (index?, ((invoiceUid?, invoiceMark?, classificationMark?, cancellationMark?, authenticationCode?)|errors), statusCode)
    /// </para>
    /// </summary>
    public virtual System.Nullable<long> invoiceMark {
        get {
            XElement x = this.GetElement(System.Xml.Linq.XName.Get("invoiceMark", ""));
            if ((x == null)) {
                return null;
            }
            return XTypedServices.ParseValue<long>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Long).Datatype);
        }
        set {
            this.SetElement(System.Xml.Linq.XName.Get("invoiceMark", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Long).Datatype);
        }
    }
    
    /// <summary>
    /// <para>
    /// Μοναδικός Αριθμός Παραλαβής Χαρακτηρισμού
    /// </para>
    /// <para>
    /// Occurrence: optional
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: (index?, ((invoiceUid?, invoiceMark?, classificationMark?, cancellationMark?, authenticationCode?)|errors), statusCode)
    /// </para>
    /// </summary>
    public virtual System.Nullable<long> classificationMark {
        get {
            XElement x = this.GetElement(System.Xml.Linq.XName.Get("classificationMark", ""));
            if ((x == null)) {
                return null;
            }
            return XTypedServices.ParseValue<long>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Long).Datatype);
        }
        set {
            this.SetElement(System.Xml.Linq.XName.Get("classificationMark", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Long).Datatype);
        }
    }
    
    /// <summary>
    /// <para>
    /// Μοναδικός Αριθμός Ακύρωσης
    /// </para>
    /// <para>
    /// Occurrence: optional
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: (index?, ((invoiceUid?, invoiceMark?, classificationMark?, cancellationMark?, authenticationCode?)|errors), statusCode)
    /// </para>
    /// </summary>
    public virtual System.Nullable<long> cancellationMark {
        get {
            XElement x = this.GetElement(System.Xml.Linq.XName.Get("cancellationMark", ""));
            if ((x == null)) {
                return null;
            }
            return XTypedServices.ParseValue<long>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Long).Datatype);
        }
        set {
            this.SetElement(System.Xml.Linq.XName.Get("cancellationMark", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Long).Datatype);
        }
    }
    
    /// <summary>
    /// <para>
    /// Συμβολοσειρά Αυθεντικοποίησης Παρόχου
    /// </para>
    /// <para>
    /// Occurrence: optional
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: (index?, ((invoiceUid?, invoiceMark?, classificationMark?, cancellationMark?, authenticationCode?)|errors), statusCode)
    /// </para>
    /// </summary>
    public virtual string authenticationCode {
        get {
            XElement x = this.GetElement(System.Xml.Linq.XName.Get("authenticationCode", ""));
            return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
        }
        set {
            this.SetElement(System.Xml.Linq.XName.Get("authenticationCode", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
        }
    }
    
    /// <summary>
    /// <para>
    /// Λίστα Σφαλμάτων
    /// </para>
    /// <para>
    /// Occurrence: required, choice
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: (index?, ((invoiceUid?, invoiceMark?, classificationMark?, cancellationMark?, authenticationCode?)|errors), statusCode)
    /// </para>
    /// </summary>
    public virtual errorsLocalType errors {
        get {
            XElement x = this.GetElement(System.Xml.Linq.XName.Get("errors", ""));
            return ((errorsLocalType)(x));
        }
        set {
            this.SetElement(System.Xml.Linq.XName.Get("errors", ""), value);
        }
    }
    
    /// <summary>
    /// <para>
    /// Κωδικός αποτελέσματος
    /// </para>
    /// <para>
    /// Occurrence: required
    /// </para>
    /// <para>
    /// Regular expression: (index?, ((invoiceUid?, invoiceMark?, classificationMark?, cancellationMark?, authenticationCode?)|errors), statusCode)
    /// </para>
    /// </summary>
    public virtual string statusCode {
        get {
            XElement x = this.GetElement(System.Xml.Linq.XName.Get("statusCode", ""));
            return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
        }
        set {
            this.SetElement(System.Xml.Linq.XName.Get("statusCode", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
        }
    }
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    Dictionary<System.Xml.Linq.XName, System.Type> IXMetaData.LocalElementsDictionary {
        get {
            return localElementDictionary;
        }
    }
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    System.Xml.Linq.XName IXMetaData.SchemaName {
        get {
            return System.Xml.Linq.XName.Get("ResponseType", "");
        }
    }
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    SchemaOrigin IXMetaData.TypeOrigin {
        get {
            return SchemaOrigin.Fragment;
        }
    }
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    ILinqToXsdTypeManager IXMetaData.TypeManager {
        get {
            return LinqToXsdTypeManager.Instance;
        }
    }
    
    public override XTypedElement Clone() {
        return XTypedServices.CloneXTypedElement<ResponseType>(this);
    }
    
    private static void BuildElementDictionary() {
        localElementDictionary.Add(System.Xml.Linq.XName.Get("index", ""), typeof(int));
        localElementDictionary.Add(System.Xml.Linq.XName.Get("invoiceUid", ""), typeof(string));
        localElementDictionary.Add(System.Xml.Linq.XName.Get("invoiceMark", ""), typeof(long));
        localElementDictionary.Add(System.Xml.Linq.XName.Get("classificationMark", ""), typeof(long));
        localElementDictionary.Add(System.Xml.Linq.XName.Get("cancellationMark", ""), typeof(long));
        localElementDictionary.Add(System.Xml.Linq.XName.Get("authenticationCode", ""), typeof(string));
        localElementDictionary.Add(System.Xml.Linq.XName.Get("errors", ""), typeof(errorsLocalType));
        localElementDictionary.Add(System.Xml.Linq.XName.Get("statusCode", ""), typeof(string));
    }
    
    ContentModelEntity IXMetaData.GetContentModel() {
        return ContentModelEntity.Default;
    }
    
    /// <summary>
    /// <para>
    /// Regular expression: (error+)
    /// </para>
    /// </summary>
    public partial class errorsLocalType : XTypedElement, IXMetaData {
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XTypedList<ErrorType> errorField;
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static Dictionary<System.Xml.Linq.XName, System.Type> localElementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static ContentModelEntity contentModel;
        
        public static explicit operator errorsLocalType(XElement xe) { return XTypedServices.ToXTypedElement<errorsLocalType>(xe,LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }
        
        static errorsLocalType() {
            BuildElementDictionary();
            contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(System.Xml.Linq.XName.Get("error", "")));
        }
        
        /// <summary>
        /// <para>
        /// Regular expression: (error+)
        /// </para>
        /// </summary>
        public errorsLocalType() {
        }
        
        /// <summary>
        /// <para>
        /// Occurrence: required, repeating
        /// </para>
        /// <para>
        /// Regular expression: (error+)
        /// </para>
        /// </summary>
        public virtual IList<ErrorType> error {
            get {
                if ((this.errorField == null)) {
                    this.errorField = new XTypedList<ErrorType>(this, LinqToXsdTypeManager.Instance, System.Xml.Linq.XName.Get("error", ""));
                }
                return this.errorField;
            }
            set {
                if ((value == null)) {
                    this.errorField = null;
                }
                else {
                    if ((this.errorField == null)) {
                        this.errorField = XTypedList<ErrorType>.Initialize(this, LinqToXsdTypeManager.Instance, value, System.Xml.Linq.XName.Get("error", ""));
                    }
                    else {
                        XTypedServices.SetList<ErrorType>(this.errorField, value);
                    }
                }
            }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Dictionary<System.Xml.Linq.XName, System.Type> IXMetaData.LocalElementsDictionary {
            get {
                return localElementDictionary;
            }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        System.Xml.Linq.XName IXMetaData.SchemaName {
            get {
                return System.Xml.Linq.XName.Get("errors", "");
            }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        SchemaOrigin IXMetaData.TypeOrigin {
            get {
                return SchemaOrigin.Fragment;
            }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILinqToXsdTypeManager IXMetaData.TypeManager {
            get {
                return LinqToXsdTypeManager.Instance;
            }
        }
        
        public override XTypedElement Clone() {
            return XTypedServices.CloneXTypedElement<errorsLocalType>(this);
        }
        
        private static void BuildElementDictionary() {
            localElementDictionary.Add(System.Xml.Linq.XName.Get("error", ""), typeof(ErrorType));
        }
        
        ContentModelEntity IXMetaData.GetContentModel() {
            return contentModel;
        }
    }
}

/// <summary>
/// <para>
/// Regular expression: (message, code)
/// </para>
/// </summary>
public partial class ErrorType : XTypedElement, IXMetaData {
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static Dictionary<System.Xml.Linq.XName, System.Type> localElementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static ContentModelEntity contentModel;
    
    public static explicit operator ErrorType(XElement xe) { return XTypedServices.ToXTypedElement<ErrorType>(xe,LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }
    
    static ErrorType() {
        BuildElementDictionary();
        contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(System.Xml.Linq.XName.Get("message", "")), new NamedContentModelEntity(System.Xml.Linq.XName.Get("code", "")));
    }
    
    /// <summary>
    /// <para>
    /// Regular expression: (message, code)
    /// </para>
    /// </summary>
    public ErrorType() {
    }
    
    /// <summary>
    /// <para>
    /// Μήνυμα Σφάλματος
    /// </para>
    /// <para>
    /// Occurrence: required
    /// </para>
    /// <para>
    /// Regular expression: (message, code)
    /// </para>
    /// </summary>
    public virtual string message {
        get {
            XElement x = this.GetElement(System.Xml.Linq.XName.Get("message", ""));
            return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
        }
        set {
            this.SetElement(System.Xml.Linq.XName.Get("message", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
        }
    }
    
    /// <summary>
    /// <para>
    /// Κωδικός Σφάλματος
    /// </para>
    /// <para>
    /// Occurrence: required
    /// </para>
    /// <para>
    /// Regular expression: (message, code)
    /// </para>
    /// </summary>
    public virtual int code {
        get {
            XElement x = this.GetElement(System.Xml.Linq.XName.Get("code", ""));
            return XTypedServices.ParseValue<int>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Int).Datatype);
        }
        set {
            this.SetElement(System.Xml.Linq.XName.Get("code", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Int).Datatype);
        }
    }
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    Dictionary<System.Xml.Linq.XName, System.Type> IXMetaData.LocalElementsDictionary {
        get {
            return localElementDictionary;
        }
    }
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    System.Xml.Linq.XName IXMetaData.SchemaName {
        get {
            return System.Xml.Linq.XName.Get("ErrorType", "");
        }
    }
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    SchemaOrigin IXMetaData.TypeOrigin {
        get {
            return SchemaOrigin.Fragment;
        }
    }
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    ILinqToXsdTypeManager IXMetaData.TypeManager {
        get {
            return LinqToXsdTypeManager.Instance;
        }
    }
    
    public override XTypedElement Clone() {
        return XTypedServices.CloneXTypedElement<ErrorType>(this);
    }
    
    private static void BuildElementDictionary() {
        localElementDictionary.Add(System.Xml.Linq.XName.Get("message", ""), typeof(string));
        localElementDictionary.Add(System.Xml.Linq.XName.Get("code", ""), typeof(int));
    }
    
    ContentModelEntity IXMetaData.GetContentModel() {
        return contentModel;
    }
}

public class LinqToXsdTypeManager : ILinqToXsdTypeManager {
    
    private static Dictionary<System.Xml.Linq.XName, System.Type> typeDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();
    
    private static Dictionary<System.Xml.Linq.XName, System.Type> elementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();
    
    private static XmlSchemaSet schemaSet;
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static LinqToXsdTypeManager typeManagerSingleton = new LinqToXsdTypeManager();
    
    static LinqToXsdTypeManager() {
        BuildTypeDictionary();
        BuildElementDictionary();
    }
    
    private LinqToXsdTypeManager() {
    }
    
    XmlSchemaSet ILinqToXsdTypeManager.Schemas {
        get {
            if ((schemaSet == null)) {
                XmlSchemaSet tempSet = new XmlSchemaSet();
                System.Threading.Interlocked.CompareExchange(ref schemaSet, tempSet, null);
            }
            return schemaSet;
        }
        set {
            schemaSet = value;
        }
    }
    
    Dictionary<System.Xml.Linq.XName, System.Type> ILinqToXsdTypeManager.GlobalTypeDictionary {
        get {
            return typeDictionary;
        }
    }
    
    Dictionary<System.Xml.Linq.XName, System.Type> ILinqToXsdTypeManager.GlobalElementDictionary {
        get {
            return elementDictionary;
        }
    }
    
    Dictionary<System.Type, System.Type> ILinqToXsdTypeManager.RootContentTypeMapping {
        get {
            return XTypedServices.EmptyTypeMappingDictionary;
        }
    }
    
    public static LinqToXsdTypeManager Instance {
        get {
            return typeManagerSingleton;
        }
    }
    
    private static void BuildTypeDictionary() {
        typeDictionary.Add(System.Xml.Linq.XName.Get("ResponseType", ""), typeof(global::Upio.MyData.BlackBox.Core.Schema.ResponseType));
        typeDictionary.Add(System.Xml.Linq.XName.Get("ErrorType", ""), typeof(global::Upio.MyData.BlackBox.Core.Schema.ErrorType));
    }
    
    private static void BuildElementDictionary() {
        elementDictionary.Add(System.Xml.Linq.XName.Get("ResponseDoc", ""), typeof(global::Upio.MyData.BlackBox.Core.Schema.ResponseDoc));
    }
    
    protected internal static void AddSchemas(XmlSchemaSet schemas) {
        schemas.Add(schemaSet);
    }
    
    public static System.Type GetRootType() {
        return elementDictionary[System.Xml.Linq.XName.Get("ResponseDoc", "")];
    }
}

public partial class XRootNamespace {
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XDocument doc;
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XTypedElement rootObject;
    

    public ResponseDoc ResponseDoc {  get {return rootObject as ResponseDoc; } }
    
    private XRootNamespace() {
    }
    
    public XRootNamespace(ResponseDoc root) {
        this.doc = new XDocument(root.Untyped);
        this.rootObject = root;
    }
    
    public virtual XDocument XDocument {
        get {
            return doc;
        }
    }
    
    public virtual XTypedElement Root {
        get {
            return rootObject;
        }
    }
    
    public static XRootNamespace Load(string xmlFile) {
        XRootNamespace root = new XRootNamespace();
        root.doc = XDocument.Load(xmlFile);
        XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
        if ((typedRoot == null)) {
            throw new LinqToXsdException("Invalid root element in xml document.");
        }
        root.rootObject = typedRoot;
        return root;
    }
    
    public static XRootNamespace Load(string xmlFile, LoadOptions options) {
        XRootNamespace root = new XRootNamespace();
        root.doc = XDocument.Load(xmlFile, options);
        XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
        if ((typedRoot == null)) {
            throw new LinqToXsdException("Invalid root element in xml document.");
        }
        root.rootObject = typedRoot;
        return root;
    }
    
    public static XRootNamespace Load(TextReader textReader) {
        XRootNamespace root = new XRootNamespace();
        root.doc = XDocument.Load(textReader);
        XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
        if ((typedRoot == null)) {
            throw new LinqToXsdException("Invalid root element in xml document.");
        }
        root.rootObject = typedRoot;
        return root;
    }
    
    public static XRootNamespace Load(TextReader textReader, LoadOptions options) {
        XRootNamespace root = new XRootNamespace();
        root.doc = XDocument.Load(textReader, options);
        XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
        if ((typedRoot == null)) {
            throw new LinqToXsdException("Invalid root element in xml document.");
        }
        root.rootObject = typedRoot;
        return root;
    }
    
    public static XRootNamespace Load(XmlReader xmlReader) {
        XRootNamespace root = new XRootNamespace();
        root.doc = XDocument.Load(xmlReader);
        XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
        if ((typedRoot == null)) {
            throw new LinqToXsdException("Invalid root element in xml document.");
        }
        root.rootObject = typedRoot;
        return root;
    }
    
    public static XRootNamespace Parse(string text) {
        XRootNamespace root = new XRootNamespace();
        root.doc = XDocument.Parse(text);
        XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
        if ((typedRoot == null)) {
            throw new LinqToXsdException("Invalid root element in xml document.");
        }
        root.rootObject = typedRoot;
        return root;
    }
    
    public static XRootNamespace Parse(string text, LoadOptions options) {
        XRootNamespace root = new XRootNamespace();
        root.doc = XDocument.Parse(text, options);
        XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
        if ((typedRoot == null)) {
            throw new LinqToXsdException("Invalid root element in xml document.");
        }
        root.rootObject = typedRoot;
        return root;
    }
    
    public virtual void Save(string fileName) {
        doc.Save(fileName);
    }
    
    public virtual void Save(TextWriter textWriter) {
        doc.Save(textWriter);
    }
    
    public virtual void Save(XmlWriter writer) {
        doc.Save(writer);
    }
    
    public virtual void Save(TextWriter textWriter, SaveOptions options) {
        doc.Save(textWriter, options);
    }
    
    public virtual void Save(string fileName, SaveOptions options) {
        doc.Save(fileName, options);
    }
}

public partial class XRoot {
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XDocument doc;
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XTypedElement rootObject;
    

    public ResponseDoc ResponseDoc {  get {return rootObject as ResponseDoc; } }
    
    private XRoot() {
    }
    
    public XRoot(ResponseDoc root) {
        this.doc = new XDocument(root.Untyped);
        this.rootObject = root;
    }
    
    public virtual XDocument XDocument {
        get {
            return doc;
        }
    }
    
    public virtual XTypedElement Root {
        get {
            return rootObject;
        }
    }
    
    public static XRoot Load(string xmlFile) {
        XRoot root = new XRoot();
        root.doc = XDocument.Load(xmlFile);
        XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
        if ((typedRoot == null)) {
            throw new LinqToXsdException("Invalid root element in xml document.");
        }
        root.rootObject = typedRoot;
        return root;
    }
    
    public static XRoot Load(string xmlFile, LoadOptions options) {
        XRoot root = new XRoot();
        root.doc = XDocument.Load(xmlFile, options);
        XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
        if ((typedRoot == null)) {
            throw new LinqToXsdException("Invalid root element in xml document.");
        }
        root.rootObject = typedRoot;
        return root;
    }
    
    public static XRoot Load(TextReader textReader) {
        XRoot root = new XRoot();
        root.doc = XDocument.Load(textReader);
        XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
        if ((typedRoot == null)) {
            throw new LinqToXsdException("Invalid root element in xml document.");
        }
        root.rootObject = typedRoot;
        return root;
    }
    
    public static XRoot Load(TextReader textReader, LoadOptions options) {
        XRoot root = new XRoot();
        root.doc = XDocument.Load(textReader, options);
        XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
        if ((typedRoot == null)) {
            throw new LinqToXsdException("Invalid root element in xml document.");
        }
        root.rootObject = typedRoot;
        return root;
    }
    
    public static XRoot Load(XmlReader xmlReader) {
        XRoot root = new XRoot();
        root.doc = XDocument.Load(xmlReader);
        XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
        if ((typedRoot == null)) {
            throw new LinqToXsdException("Invalid root element in xml document.");
        }
        root.rootObject = typedRoot;
        return root;
    }
    
    public static XRoot Parse(string text) {
        XRoot root = new XRoot();
        root.doc = XDocument.Parse(text);
        XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
        if ((typedRoot == null)) {
            throw new LinqToXsdException("Invalid root element in xml document.");
        }
        root.rootObject = typedRoot;
        return root;
    }
    
    public static XRoot Parse(string text, LoadOptions options) {
        XRoot root = new XRoot();
        root.doc = XDocument.Parse(text, options);
        XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
        if ((typedRoot == null)) {
            throw new LinqToXsdException("Invalid root element in xml document.");
        }
        root.rootObject = typedRoot;
        return root;
    }
    
    public virtual void Save(string fileName) {
        doc.Save(fileName);
    }
    
    public virtual void Save(TextWriter textWriter) {
        doc.Save(textWriter);
    }
    
    public virtual void Save(XmlWriter writer) {
        doc.Save(writer);
    }
    
    public virtual void Save(TextWriter textWriter, SaveOptions options) {
        doc.Save(textWriter, options);
    }
    
    public virtual void Save(string fileName, SaveOptions options) {
        doc.Save(fileName, options);
    }
}