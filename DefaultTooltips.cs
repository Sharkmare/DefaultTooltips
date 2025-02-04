﻿using FrooxEngine;
using FrooxEngine.UIX;
using NeosModLoader;
using System.Collections.Generic;
using System.Text.Json;

namespace DefaultTooltips
{
    public class DefaultTooltips : NeosMod
    {
        public override string Name => "DefaultTooltips";
        public override string Author => "Psychpsyo";
        public override string Version => "1.1.0";
        public override string Link => "https://github.com/Psychpsyo/DefaultTooltips";

        private static Dictionary<string, string> createNewLabelDict = new Dictionary<string, string>()
        {
            {"", "general.back"},
            {"/0", "createNew.emptyObject"},
            {"/1", "createNew.particleSystem"},
            {"/3DModel", "createNew.3DModelMenu"},
            {"/3DModel/0", "createNew.3DModel.box"},
            {"/3DModel/1", "createNew.3DModel.capsule"},
            {"/3DModel/2", "createNew.3DModel.cone"},
            {"/3DModel/3", "createNew.3DModel.cylinder"},
            {"/3DModel/4", "createNew.3DModel.grid"},
            {"/3DModel/5", "createNew.3DModel.quad"},
            {"/3DModel/6", "createNew.3DModel.sphere"},
            {"/3DModel/7", "createNew.3DModel.torus"},
            {"/3DModel/8", "createNew.3DModel.triangle"},
            {"/Collider", "createNew.colliderMenu"},
            {"/Collider/0", "createNew.collider.box"},
            {"/Collider/1", "createNew.collider.capsule"},
            {"/Collider/2", "createNew.collider.cone"},
            {"/Collider/3", "createNew.collider.cylinder"},
            {"/Collider/4", "createNew.collider.mesh"},
            {"/Collider/5", "createNew.collider.sphere"},
            {"/Editor", "createNew.editorMenu"},
            {"/Editor/0", "createNew.editor.assetOptimizationWizard"},
            {"/Editor/1", "createNew.editor.cubemapCreator"},
            {"/Editor/2", "createNew.editor.worldLightSourcesWizard"},
            {"/Editor/3", "createNew.editor.logixTransferWizard"},
            {"/Editor/4", "createNew.editor.reflectionProbeWizard"},
            {"/Editor/5", "createNew.editor.worldTextRendererWizard"},
            {"/Editor/6", "createNew.editor.userInspector"},
            {"/Light", "createNew.lightMenu"},
            {"/Light/0", "createNew.light.directional"},
            {"/Light/1", "createNew.light.point"},
            {"/Light/2", "createNew.light.spot"},
            {"/Materials", "createNew.materialMenu"},
            {"/Object", "createNew.objectMenu"},
            {"/Text", "createNew.textMenu"},
            {"/Text/0", "createNew.text.Basic"},
            {"/Text/1", "createNew.text.Outline"}
        };

        private static Dictionary<string, string> inspectorLabelDict = new Dictionary<string, string>()
        {
            {"OnObjectRootPressed", "inspector.objectRoot"},
            {"OnRootUpPressed", "inspector.hierarchyUp"},
            {"OnDestroyPressed", "inspector.destroySlot"},
            {"OnDestroyPreservingAssetsPressed", "inspector.destroyPreserveAssets"},
            {"OnInsertParentPressed", "inspector.insertParent"},
            {"OnAddChildPressed", "inspector.addChild"},
            {"OnDuplicatePressed", "inspector.duplicateSlot"},
            {"OnSetRootPressed", "inspector.focusHierarchyHere"},
            {"OnAttachComponentPressed", "inspector.attachComponent"}
        };

        private static Dictionary<string, string> inventoryLabelDict = new Dictionary<string, string>()
        {
            {"ShowInventoryOwners", "inventory.groups"},
            {"GenerateLink", "inventory.spawnFolder"},
            {"MakePrivate", "inventory.makePrivate"},
            {"DeleteItem", "inventory.delete"},
            {"AddCurrentAvatar", "inventory.saveAvatar"},
            {"AddNew", "inventory.addNew"},
            {"OnOpenWorld", "inventory.openWorld"},
            {"OnEquipAvatar", "inventory.equipAvatar"},
            {"OnSetDefaultHome", "inventory.favHome"},
            {"OnSetDefaultAvatar", "inventory.favAvatar"},
            {"OnSetDefaultKeyboard", "inventory.favKeyboard"},
            {"OnSetDefaultCamera", "inventory.favCamera"},
            {"OnSpawnFacet", "inventory.spawnFacet"}
        };

        private static Dictionary<VoiceMode, string> voiceFacetLabelDict = new Dictionary<VoiceMode, string>()
        {
            {VoiceMode.Whisper, "voiceModes.whisper"},
            {VoiceMode.Normal, "voiceModes.normal"},
            {VoiceMode.Shout, "voiceModes.shout"},
            {VoiceMode.Broadcast, "voiceModes.broadcast"},
        };

        private static Dictionary<CloudX.Shared.OnlineStatus, string> onlineStatusFacetLabelDict = new Dictionary<CloudX.Shared.OnlineStatus, string>()
        {
            {CloudX.Shared.OnlineStatus.Online, "onlineStatus.online"},
            {CloudX.Shared.OnlineStatus.Away, "onlineStatus.away"},
            {CloudX.Shared.OnlineStatus.Busy, "onlineStatus.busy"},
            {CloudX.Shared.OnlineStatus.Invisible, "onlineStatus.invisible"},
        };

        private static Dictionary<string, string> fileBrowserLabelDict = new Dictionary<string, string>()
        {
            {"RunImport", "fileBrowser.import"},
            {"RunRawImport", "fileBrowser.importRaw"},
            {"CreateNew", "fileBrowser.addNew"},
            {"Reload", "fileBrowser.refresh"}
        };

        private static Dictionary<string, string> imageImportLabelDict = new Dictionary<string, string>()
        {
            {"Return", "general.back"},
            {"Preset_Image", "imageImport.image"},
            {"Preset_Screenshot", "imageImport.screenshot"},
            {"Preset_360", "imageImport.360"},
            {"Preset_StereoImage", "imageImport.stereo"},
            {"Preset_Stereo360", "imageImport.stereo360"},
            {"Preset_180", "imageImport.180"},
            {"Preset_Stereo180", "imageImport.stereo180"},
            {"Preset_LUT", "imageImport.lut"},
            {"AsRawFile", "imageImport.rawFile"},
            {"Preset_HorizontalLR", "imageImport.stereo.horizontalLR"},
            {"Preset_HorizontalRL", "imageImport.stereo.horizontalRL"},
            {"Preset_VerticalLR", "imageImport.stereo.verticalLR"},
            {"Preset_VerticalRL", "imageImport.stereo.verticalRL"}
        };

        private static Dictionary<string, string> videoImportLabelDict = new Dictionary<string, string>()
        {
            {"Return", "general.back"},
            {"Preset_Video", "videoImport.video"},
            {"Preset_360", "videoImport.360"},
            {"Preset_StereoVideo", "videoImport.stereo"},
            {"Preset_Stereo360", "videoImport.stereo360"},
            {"Preset_Depth", "videoImport.depth"},
            {"Preset_180", "videoImport.180"},
            {"Preset_Stereo180", "videoImport.stereo180"},
            {"AsRawFile", "videoImport.rawFile"},
            {"Preset_HorizontalLR", "videoImport.stereo.horizontalLR"},
            {"Preset_HorizontalRL", "videoImport.stereo.horizontalRL"},
            {"Preset_VerticalLR", "videoImport.stereo.verticalLR"},
            {"Preset_VerticalRL", "videoImport.stereo.verticalRL"},
            {"Preset_DepthDefault", "videoImport.depth.default"},
            {"Preset_DepthPFCapture", "videoImport.depth.PFCapture"},
            {"Preset_DepthPFCaptureHorizontal", "videoImport.depth.PFCaptureHorizontal"},
            {"Preset_DepthHolofix", "videoImport.depth.holofix"}
        };

        private static Dictionary<string, string> avatarCreatorLabelDict = new Dictionary<string, string>()
        {
            {"AlignHeadForward", "avatarCreator.alignHeadForward"},
            {"AlignHeadUp", "avatarCreator.alignHeadUp"},
            {"AlignHeadRight", "avatarCreator.alignHeadRight"},
            {"AlignHeadPosition", "avatarCreator.centerHeadPosition"},
            {"AlignHands", "avatarCreator.alignHands"},
            {"AlignToolAnchors", "avatarCreator.alignToolAnchors"},
            {"_useSymmetry", "avatarCreator.useSymmetry"},
            {"_showAnchors", "avatarCreator.showAnchors"},
            {"_setupVolumeMeter", "avatarCreator.setupVolumeMeter"},
            {"_setupEyes", "avatarCreator.setupEyes"},
            {"_setupFaceTracking", "avatarCreator.setupFaceTracking"},
            {"_setupProtection", "avatarCreator.protectAvatar"},
            {"OnCreate", "avatarCreator.create"}
        };

        private static Dictionary<string, string> localeStrings;

        public override void OnEngineInit()
        {
            // load localized text
            string language;
            Settings.TryReadValue<string>("Interface.Locale", out language);
            try
            {
                localeStrings = JsonSerializer.Deserialize<Dictionary<string, string>>(System.IO.File.ReadAllText(@"./nml_mods/defaultTooltips/locales/" + language + ".json"));
            }
            catch
            {
                localeStrings = JsonSerializer.Deserialize<Dictionary<string, string>>(System.IO.File.ReadAllText(@"./nml_mods/defaultTooltips/locales/en.json"));
            }


            // add label providers to Tooltippery mod
            Tooltippery.Tooltippery.labelProviders.Add(inspectorLabels);
            Tooltippery.Tooltippery.labelProviders.Add(createNewLabels);
            Tooltippery.Tooltippery.labelProviders.Add(inventoryLabels);
            Tooltippery.Tooltippery.labelProviders.Add(voiceFacetLabels);
            Tooltippery.Tooltippery.labelProviders.Add(fileBrowserLabels);
            Tooltippery.Tooltippery.labelProviders.Add(imageImportLabels);
            Tooltippery.Tooltippery.labelProviders.Add(videoImportLabels);
            Tooltippery.Tooltippery.labelProviders.Add(avatarCreatorLabels);
            Tooltippery.Tooltippery.labelProviders.Add(onlineStatusFacetLabels);
        }

        private static string createNewLabels(IButton button, ButtonEventData eventData)
        {
            if (button.Slot.GetComponentInParents<DevCreateNewForm>() == null) return null;
            string target = button.Slot.GetComponent<ButtonRelay<string>>()?.Argument.Value;
            if (target == null) return null;
            if (createNewLabelDict.TryGetValue(target, out target)) return localeStrings[target];
            return null;
        }

        private static string inspectorLabels(IButton button, ButtonEventData eventData)
        {
            // only care for buttons on the UIX Canvas for now:
            if (button.GetType() != typeof(Button)) return null;

            // get the inspector and target method of the button
            SceneInspector inspector = button.Slot.GetComponentInParents<SceneInspector>();
            if (inspector == null) return null;

            WorldDelegate? buttonTarget = null;
            if (((Button)button).Pressed?.Target != null) buttonTarget = ((Button)button).Pressed.Value;
            if (button.Slot.GetComponent<ButtonRelay>()?.ButtonPressed?.Target != null) buttonTarget = button.Slot.GetComponent<ButtonRelay>()?.ButtonPressed?.Value;
            if (!buttonTarget.HasValue) return null;

            string methodName = buttonTarget.Value.method;

            // is this button is calling a function of the inspector itself?
            if (buttonTarget.Value.target == inspector.ReferenceID)
            {
                string retVal;
                if (inspectorLabelDict.TryGetValue(methodName, out retVal)) return localeStrings[retVal];
            }

            return null;
        }

        private static string inventoryLabels(IButton button, ButtonEventData eventData)
        {
            InventoryBrowser inventory = button.Slot.GetComponentInParents<InventoryBrowser>();
            if (inventory == null) return null;

            WorldDelegate? buttonTarget = null;
            if (((Button)button).Pressed?.Target != null)
            {
                buttonTarget = ((Button)button).Pressed.Value;
            }
            else if (button.Slot.GetComponent<ButtonRelay>()?.ButtonPressed?.Target != null)
            {
                buttonTarget = button.Slot.GetComponent<ButtonRelay>().ButtonPressed.Value;
            }
            // back buttons
            else if (button.Slot.GetComponent<ButtonRelay<int>>()?.ButtonPressed?.Target != null)
            {
                ButtonRelay<int> relay = button.Slot.GetComponent<ButtonRelay<int>>();
                buttonTarget = relay.ButtonPressed?.Value;
                if (!buttonTarget.HasValue) return null;
                if (buttonTarget.Value.method == "OnGoUp")
                {
                    string[] path = inventory.CurrentPath == "" ? new[] { "Inventory" } : ("Inventory\\" + inventory.CurrentPath).Split('\\');
                    return localeStrings["general.goBackTo"].Replace("{{FOLDER}}", path[path.Length - 1 - relay.Argument]);
                }
                else
                {
                    return null;
                }
            }
            if (!buttonTarget.HasValue) return null;

            string methodName = buttonTarget.Value.method;

            // is this button is calling a function of the inspector itself?
            if (buttonTarget.Value.target == inventory.ReferenceID)
            {
                string retVal;
                if (inventoryLabelDict.TryGetValue(methodName, out retVal)) return localeStrings[retVal];
            }

            return null;
        }

        private static string voiceFacetLabels(IButton button, ButtonEventData eventData)
        {
            if (button.Slot.GetComponentInParents<VoiceFacetPreset>() == null) return null;
            VoiceMode? targetVoiceMode = button.Slot.GetComponent<ButtonValueSet<VoiceMode>>()?.SetValue.Value;
            if (!targetVoiceMode.HasValue)
            {
                IField<bool> targetToggle = button.Slot.GetComponent<ButtonToggle>()?.TargetValue.Target;
                if (targetToggle?.Name == "GlobalMute")
                {
                    return targetToggle.Value ? localeStrings["voiceModes.unmute"] : localeStrings["voiceModes.mute"];
                }
                return null;
            }

            return localeStrings[voiceFacetLabelDict[targetVoiceMode.Value]];
        }

        private static string onlineStatusFacetLabels(IButton button, ButtonEventData eventData)
        {
            if (button.Slot.GetComponentInParents<OnlineStatusFacetPreset>() == null) return null;
            CloudX.Shared.OnlineStatus? targetStatus = button.Slot.GetComponent<ButtonValueSet<CloudX.Shared.OnlineStatus>>()?.SetValue.Value;
            if (!targetStatus.HasValue) return null;

            string retVal = null;
            onlineStatusFacetLabelDict.TryGetValue(targetStatus.Value, out retVal);
            return localeStrings[retVal];
        }

        private static string fileBrowserLabels(IButton button, ButtonEventData eventData)
        {
            FileBrowser fileBrowser = button.Slot.GetComponentInParents<FileBrowser>();
            if (fileBrowser == null) return null;

            WorldDelegate? buttonTarget = null;
            if (((Button)button).Pressed?.Target != null)
            {
                buttonTarget = ((Button)button).Pressed.Value;
            }
            else if (button.Slot.GetComponent<ButtonRelay>()?.ButtonPressed?.Target != null)
            {
                buttonTarget = button.Slot.GetComponent<ButtonRelay>().ButtonPressed.Value;
            }
            // back buttons
            else if (button.Slot.GetComponent<ButtonRelay<int>>()?.ButtonPressed?.Target != null)
            {
                ButtonRelay<int> relay = button.Slot.GetComponent<ButtonRelay<int>>();
                buttonTarget = relay.ButtonPressed?.Value;
                if (!buttonTarget.HasValue) return null;
                if (buttonTarget.Value.method == "OnGoUp")
                {
                    string[] path = fileBrowser.CurrentPath == null ? new[] { "Computer" } : ("Computer\\" + fileBrowser.CurrentPath).Split('\\');
                    return localeStrings["general.goBackTo"].Replace("{{FOLDER}}", path[path.Length - 1 - relay.Argument]);
                }
                else
                {
                    return null;
                }
            }
            if (!buttonTarget.HasValue) return null;

            string methodName = buttonTarget.Value.method;

            // is this button is calling a function of the inspector itself?
            if (buttonTarget.Value.target == fileBrowser.ReferenceID)
            {
                string retVal;
                if (fileBrowserLabelDict.TryGetValue(methodName, out retVal)) return localeStrings[retVal];
            }

            return null;
        }
        private static string imageImportLabels(IButton button, ButtonEventData eventData)
        {
            // only care for buttons on the UIX Canvas for now:
            if (button.GetType() != typeof(Button)) return null;

            if (button.Slot.GetComponentInParents<ImageImportDialog>() == null) return null;
            if (((Button)button).Pressed?.Target == null) return null;
            string target = ((Button)button).Pressed.Value.method;
            if (imageImportLabelDict.TryGetValue(target, out target)) return localeStrings[target];
            return null;
        }
        private static string videoImportLabels(IButton button, ButtonEventData eventData)
        {
            // only care for buttons on the UIX Canvas for now:
            if (button.GetType() != typeof(Button)) return null;

            if (button.Slot.GetComponentInParents<VideoImportDialog>() == null) return null;
            string target = null;
            if (((Button)button).Pressed?.Target != null) target = ((Button)button).Pressed.Value.method;
            if (button.Slot.GetComponent<ButtonRelay>() != null) target = button.Slot.GetComponent<ButtonRelay>().ButtonPressed?.Value.method;
            if (target == null) return null;
            if (videoImportLabelDict.TryGetValue(target, out target)) return localeStrings[target];
            return null;
        }
        private static string avatarCreatorLabels(IButton button, ButtonEventData eventData)
        {
            // only care for buttons on the UIX Canvas for now:
            if (button.GetType() != typeof(Button)) return null;

            if (button.Slot.GetComponentInParents<AvatarCreator>() == null) return null;
            string target = null;
            if (button.Slot.GetComponent<Checkbox>() != null) target = button.Slot.GetComponent<Checkbox>().TargetState.Target.Name;
            if (((Button)button).Pressed?.Target != null) target = ((Button)button).Pressed.Value.method;
            if (button.Slot.GetComponent<ButtonRelay>() != null) target = button.Slot.GetComponent<ButtonRelay>().ButtonPressed?.Value.method;
            if (target == null) return null;
            if (avatarCreatorLabelDict.TryGetValue(target, out target)) return localeStrings[target];
            return null;
        }
    }
}