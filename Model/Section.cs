/* 
 * Employex
 *
 * This is a sample API that allows to manage Employex system, which serves for users seeking to apply for job offers. 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: ricardorzan@gmail.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = Employex.Client.SwaggerDateConverter;

namespace Employex.Model
{
    /// <summary>
    /// Personal section that represents a remarkable event or recognition by the independent user
    /// </summary>
    [DataContract]
        public partial class Section :  IEquatable<Section>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Section" /> class.
        /// </summary>
        /// <param name="sectionId">Unique identifier of the section.</param>
        /// <param name="title">Title of the section (required).</param>
        /// <param name="description">Main text of the section (required).</param>
        /// <param name="media">Multimedia data related to the section.</param>
        public Section(int sectionId = default(int), string title = default(string), string description = default(string), List<Media> media = default(List<Media>))
        {
            // to ensure "title" is required (not null)
            if (title == null)
            {
                throw new InvalidDataException("title is a required property for Section and cannot be null");
            }
            else
            {
                this.Title = title;
            }
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new InvalidDataException("description is a required property for Section and cannot be null");
            }
            else
            {
                this.Description = description;
            }
            this.SectionId = sectionId;
            this.Media = media;
        }
        
        /// <summary>
        /// Unique identifier of the section
        /// </summary>
        /// <value>Unique identifier of the section</value>
        [DataMember(Name="section_id", EmitDefaultValue=false)]
        public int SectionId { get; set; }

        /// <summary>
        /// Title of the section
        /// </summary>
        /// <value>Title of the section</value>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// Main text of the section
        /// </summary>
        /// <value>Main text of the section</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Multimedia data related to the section
        /// </summary>
        /// <value>Multimedia data related to the section</value>
        [DataMember(Name="media", EmitDefaultValue=false)]
        public List<Media> Media { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Section {\n");
            sb.Append("  SectionId: ").Append(SectionId).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Media: ").Append(Media).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Section);
        }

        /// <summary>
        /// Returns true if Section instances are equal
        /// </summary>
        /// <param name="input">Instance of Section to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Section input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.SectionId == input.SectionId ||
                    (this.SectionId != null &&
                    this.SectionId.Equals(input.SectionId))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Media == input.Media ||
                    this.Media != null &&
                    input.Media != null &&
                    this.Media.SequenceEqual(input.Media)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.SectionId != null)
                    hashCode = hashCode * 59 + this.SectionId.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Media != null)
                    hashCode = hashCode * 59 + this.Media.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
