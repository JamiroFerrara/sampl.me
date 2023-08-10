<script lang="ts">
	import FaPlus from 'svelte-icons/fa/FaPlus.svelte';
	import FaCheck from 'svelte-icons/fa/FaCheck.svelte';

	export let added = false;
</script>

<div
	on:click={() => (added = true)}
	class="p-2 justify-center self-center cursor-pointer transition-all hover:scale-110"
>
	{#if !added}
		<div class="h-4">
			<FaPlus />
		</div>
	{/if}

	{#if added}
		<div class="h-4 text-green-300">
			<FaCheck />
		</div>
	{/if}
</div>

<style>
	.icon {
		color: red;
	}
</style>
